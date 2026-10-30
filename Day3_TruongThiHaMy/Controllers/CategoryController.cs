using Day3_TruongThiHaMy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day3_TruongThiHaMy.Controllers
{
   
    public class CategoryController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category() { Id = 1, Name = "Category 1" },
            new Category() { Id = 2, Name = "Category 2" },
            new Category() { Id = 3, Name = "Category 3" }
        };

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid) {
                int newId = categories.Any() ? categories.Max(c => c.Id) + 1 : 1;
                categories.Add(category);
                return RedirectToAction(nameof(Index));
            
            }
                return View();
        }
        

        // GET: CategoryController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        { 
            //tim category chon id
            var category = categories.FirstOrDefault(c => c.Id == id);
            //neu khong tim thay category thi tra ve notfound
            if (category == null) return NotFound();
            //neu tim thay thi tra ve view edit boi model category
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            //tim category theo id
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null) return NotFound();
            if (ModelState.IsValid)
            {
                //cap nhat thong tin category
                existingCategory.Name = category.Name;
                return RedirectToAction(nameof(Index));
            }
           
            {

                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null) { return NotFound(); }
            categories.Remove(category);
            return RedirectToAction(nameof(Index));
            
        }
    }
}