using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VakifbankPos.DAL.Context;
using VakifbankPos.DAL.Entities;

namespace VakifbankPos.Controllers
{
    public class PersonelController : Controller
    {
        private readonly VakifbankPosContext _context;

        public PersonelController(VakifbankPosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.PosReceivers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePersonel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePersonel(PosReceiver posReceiver)
        {
            _context.PosReceivers.Add(posReceiver);
            _context.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }

        public IActionResult DeletePersonel(int id)
        {
            var value = _context.PosReceivers.Find(id);
            if (value != null)
            {
                _context.PosReceivers.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePersonel(int id)
        {
            var personel = _context.PosReceivers.Find(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost]
        public IActionResult UpdatePersonel(PosReceiver personel)
        {
            
                var existingPersonel = _context.PosReceivers.Find(personel.PosReceiverId);
               

                
                existingPersonel.Name = personel.Name;
                existingPersonel.Surname = personel.Surname;
                existingPersonel.Email = personel.Email;
                existingPersonel.PhoneNumber = personel.PhoneNumber;
                existingPersonel.IdentificationNumber = personel.IdentificationNumber;

                _context.PosReceivers.Update(existingPersonel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            

           
        }

        public IActionResult Details(int id)
        {
            var personel = _context.PosReceivers.SingleOrDefault(p => p.PosReceiverId == id);
            return View(personel);
        }
    }
}