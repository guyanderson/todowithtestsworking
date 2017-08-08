using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoXUnitTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoXUnitTest.Controllers
{
    public class CategoriesController : Controller
    {
        private ToDoDbContext db = new ToDoDbContext();
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public IActionResult Details(int id)
        {
            Category thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);

            return View(thisCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Category thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Category thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            db.Categories.Remove(thisCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
