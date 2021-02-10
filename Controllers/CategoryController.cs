using BookList_Manager.Data;
using BookList_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList_Manager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DatabaseConnection _db;

        public CategoryController(DatabaseConnection db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Category> objlist = _db.Category;
            return View(objlist);
        }

        // get_create
        public IActionResult Create()
        {
            
            return View();
        }

        //post-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
            
        }

        // get_Edit
        public IActionResult Edit( int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post-update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }


        // get_Edit
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post-delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
                

            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           

        }
    }
}

