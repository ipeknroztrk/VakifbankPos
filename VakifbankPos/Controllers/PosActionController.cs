using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VakifbankPos.DAL.Context;
using VakifbankPos.DAL.Entities;
using VakifbankPos.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VakifbankPos.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class PosActionController : Controller
    {
        private readonly VakifbankPosContext _context;

        public PosActionController(VakifbankPosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.PosActions
               
                .Include(pa => pa.PosReceiver)
                .Include(pa => pa.PosInventory)
                .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult BorrowPos(int id)
        {
            var pos = _context.PosInventories.Find(id);
            if (pos == null)
            {
                return NotFound();
            }

            
            var personnelList = _context.PosReceivers
                .Select(pr => new
                {
                    PosReceiverId = pr.PosReceiverId,
                    FullName = pr.Name + " " + pr.Surname
                }).ToList();

            ViewBag.PersonnelList = new SelectList(personnelList, "PosReceiverId", "FullName");
            return View(new PosActionViewModel { PosId = id, IssueDate = DateTime.Now.Date });
        }

        [HttpPost]
        public async Task<IActionResult> BorrowPos(PosActionViewModel posActionViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.PersonnelList = new SelectList(_context.PosReceivers, "PosReceiverId", "Name", posActionViewModel.PosReceiverId);
                return View(posActionViewModel);
            }

            var selectedPersonnel = await _context.PosReceivers.FindAsync(posActionViewModel.PosReceiverId);
            if (selectedPersonnel == null)
            {
                ModelState.AddModelError("", "Personel bulunamadı.");
                ViewBag.PersonnelList = new SelectList(_context.PosReceivers, "PosReceiverId", "Name", posActionViewModel.PosReceiverId);
                return View(posActionViewModel);
            }

            var posAction = new PosAction
            {
                PosId = posActionViewModel.PosId,
                PosReceiverId = posActionViewModel.PosReceiverId,
                IssuedTo = selectedPersonnel.Name,
                IssueDate = posActionViewModel.IssueDate,
                Returned = false
            };

            _context.PosActions.Add(posAction);

           
            var posInventory = await _context.PosInventories.FindAsync(posActionViewModel.PosId);
            if (posInventory != null)
            {
                posInventory.IsDefective = false;
                posInventory.Status = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PosAction");
        }

        [HttpGet]
        public IActionResult ReturnPos(int id)
        {
            var posAction = _context.PosActions
                .Include(p => p.PosInventory)
                .FirstOrDefault(p => p.PosActionId == id && !p.Returned);

            if (posAction == null)
            {
                return NotFound();
            }

            var viewModel = new ReturnPosViewModel
            {
                PosActionId = posAction.PosActionId,
                PosId = posAction.PosId,
                IssueDate = posAction.IssueDate,
                ReturnDate = DateTime.Now.Date
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ReturnPos(ReturnPosViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var existingAction = await _context.PosActions
                .FirstOrDefaultAsync(p => p.PosActionId == viewModel.PosActionId);

            if (existingAction == null)
            {
                return NotFound();
            }

            existingAction.ReturnDate = viewModel.ReturnDate;
            existingAction.Returned = true;

            try
            {
                _context.Update(existingAction);

                // POS cihazının status alanını false yap
                var posInventory = await _context.PosInventories.FindAsync(existingAction.PosId);
                if (posInventory != null)
                {
                    posInventory.IsDefective = false;
                    posInventory.Status = false;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PosAction");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
                return View(viewModel);
            }
        }


        public async Task<IActionResult> DeletePosAction(int id)
        {
            var values = _context.PosActions.Find(id);
            _context.Remove(values);
             _context.SaveChanges();
            return RedirectToAction("Index", "PosAction");

        }


       


    }
}
