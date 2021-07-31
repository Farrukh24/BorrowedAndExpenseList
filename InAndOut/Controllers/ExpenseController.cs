using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<MyExpense> objList = _db.MyExpenses;
             return View(objList);           
        }

        // GET-create
        public IActionResult Create()
        {

            return View();
        }

        // POST-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MyExpense obj)
        {
           // if (ModelState.IsValid)
           // {
                _db.MyExpenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           // }
           // return View(obj);
        }

        // POST delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.MyExpenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.MyExpenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // GET update
        public IActionResult Update(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MyExpenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MyExpense obj)
        {
            if (ModelState.IsValid)
            {
                _db.MyExpenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
