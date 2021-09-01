using BartenderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartenderApp.Controllers
{
    public class BartenderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BartenderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Bartender> BartenderList = _db.Bartender;
            return View(BartenderList);
        }

        //This method leads you to the page that allows you to add new drinks
        public IActionResult AddDrink()
        {
            return View();
        }

        //This method will actually add the new drink to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDrink(Bartender drink)
        {
            if (ModelState.IsValid)
            {
                _db.Bartender.Add(drink);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        //This method leads you to the page that allows you to edit the drinks
        public IActionResult EditDrink(int? Id)
        {

            if (Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Bartender.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //This method will update the edit made to the drink
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDrink(Bartender drink)
        {
            if (ModelState.IsValid)
            {
                _db.Bartender.Update(drink);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drink);

        }

        //This method will get the specific entity that needs to be deleted
        public IActionResult DeleteDrink(int? Id)
        {

            if (Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Bartender.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //This method will update the database by deleting the entity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBartenderEntity(int? Id)
        {
            var entity = _db.Bartender.Find(Id);
            _db.Bartender.Remove(entity);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
