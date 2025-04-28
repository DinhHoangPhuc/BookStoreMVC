using BookStore.Data;
using BookStore.Models;
using BookStore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Catergory category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order can not exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Catergory? catergoryFromDb = _categoryRepo.Get(c => c.Id == id);
            if (catergoryFromDb == null)
            {
                return NotFound();
            }
            return View(catergoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Catergory category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(category);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Catergory? catergoryFromDb = _categoryRepo.Get(c => c.Id == id);
            if (catergoryFromDb == null)
            {
                return NotFound();
            }
            return View(catergoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Catergory? catergoryFromDb = _categoryRepo.Get(c => c.Id == id);
            if (catergoryFromDb == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(catergoryFromDb);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
