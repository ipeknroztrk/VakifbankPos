using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VakifbankPos.DAL.Context;
using VakifbankPos.DAL.Entities;
using VakifbankPos.Models;

namespace VakifbankPos.Controllers
{
    public class PosController : Controller
    {
        private readonly VakifbankPosContext _context;

        public PosController(VakifbankPosContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string ara)
        {
            
            var posList = await _context.PosInventories
                .Where(x => x.Status == false && x.IsDefective == false)
                .Select(pos => new PosInventoryViewModel
                {
                    PosId = pos.PosId,
                    SerialNumber = pos.SerialNumber,
                    Model = pos.Model,
                    OwnerBank = pos.OwnerBank,
                    Terminal = pos.Terminal,
                    LastBorrower = _context.PosActions
                        .Where(pa => pa.PosId == pos.PosId)
                        .OrderByDescending(pa => pa.IssueDate)
                        .Select(pa => pa.IssuedTo)
                        .FirstOrDefault(),
                    LastUpdatedDate = pos.IssueDate 
                })
                .ToListAsync();

            if (!string.IsNullOrEmpty(ara))
            {
                posList = posList
                    .Where(x => x.SerialNumber.Contains(ara) || x.Model.Contains(ara) || x.OwnerBank.Contains(ara) || x.Terminal.Contains(ara))
                    .ToList();
            }

            return View(posList); 
        }

        [HttpGet]
        public IActionResult CreatePos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePos(PosInventory posInventory)
        {
            posInventory.IsDefective=false;
            posInventory.Status = false;
            _context.PosInventories.Add(posInventory);
            _context.SaveChanges();
            return RedirectToAction("Index", "Pos");
        }



        [HttpGet]
        public IActionResult UpdatePos(int id)
        {
            var posInventory = _context.PosInventories.Find(id);
            if (posInventory == null)
            {
                return NotFound();
            }
            return View(posInventory);
        }

        [HttpPost]
        public IActionResult UpdatePos(PosInventory posInventory)
        {
            if (ModelState.IsValid)
            {
                
                var existingPos = _context.PosInventories.Find(posInventory.PosId);
                if (existingPos == null)
                {
                    return NotFound();
                }

               
                existingPos.PosMember = posInventory.PosMember;
                existingPos.Terminal = posInventory.Terminal;
                existingPos.SerialNumber = posInventory.SerialNumber;
                existingPos.LastIssuedTo = posInventory.LastIssuedTo;
                existingPos.IssueDate = posInventory.IssueDate;
                existingPos.Environment = posInventory.Environment;
                existingPos.Vendor = posInventory.Vendor;
                existingPos.Model = posInventory.Model;
                existingPos.OwnerBank = posInventory.OwnerBank;
                existingPos.PosType = posInventory.PosType;
                existingPos.IsDefective = posInventory.IsDefective;
                existingPos.Status = posInventory.Status;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    
                    return BadRequest($"Güncelleme sırasında bir hata oluştu: {ex.Message}");
                }

                return RedirectToAction("Index", "Pos");
            }

            
            return View(posInventory);
        }

        public async Task<IActionResult> DeletePos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posInventory = await _context.PosInventories
                .FirstOrDefaultAsync(m => m.PosId == id);
            if (posInventory == null)
            {
                return NotFound();
            }

            return View(posInventory);
        }


        [HttpPost, ActionName("DeletePos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posInventory = await _context.PosInventories.FindAsync(id);
            if (posInventory != null)
            {
                _context.PosInventories.Remove(posInventory);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PosInventoryExists(int id)
        {
            return _context.PosInventories.Any(e => e.PosId == id);
        }

        public async Task<IActionResult> PosDetail(int id)
        {


            var posInventory = await _context.PosInventories
                .FirstOrDefaultAsync(m => m.PosId == id);

            if (posInventory == null)
            {
                return NotFound();
            }

            return View(posInventory);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDefectiveStatus(int posId, bool isDefective)
        {
            var posInventory = await _context.PosInventories.FindAsync(posId);
            if (posInventory == null)
            {
                return NotFound();
            }

            posInventory.IsDefective = true;
          

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
       

           
            [HttpGet]
            public async Task<IActionResult> UpdateDefectivePassive(int id)
            {
                var pos = await _context.PosInventories.FindAsync(id);

                if (pos == null)
                {
                    return NotFound();
                }

                pos.IsDefective = false;
                _context.Update(pos);
                await _context.SaveChangesAsync();

                return RedirectToAction("DefectiveList");
            }
        





        public async Task<IActionResult> DefectiveList()
        {
            var defectivePosList = await _context.PosInventories
                .Where(x => x.IsDefective == true)
                .ToListAsync();

            return View(defectivePosList);
        }
    }

}
