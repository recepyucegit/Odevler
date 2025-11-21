using BLL.Services.Abstracts;

using DAL.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServiceManager _categoryService;

        public CategoryController(ICategoryServiceManager categoryService)
        {
            _categoryService = categoryService;
        }




        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll().ToList();
            return View(categories);
        }

        

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            //if (ModelState.IsValid)//boş geçilemez propertyler tanımlı geliyorsa.
            //{
               
            //}

            await _categoryService.CreateAsync(category);
            return RedirectToAction("Index");
        
        }

        // GET: CategoryController/Edit/5
        public ActionResult Update(int id)
        {
            var updateCategory=_categoryService.FindById(id);
            //eğer updateCategory null gelirse index sayfasına yönlendir, dolu gelirse update'view'a gönder.
            if (updateCategory == null)
            {
                return RedirectToAction("Index");
            }

            return View(updateCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(Category updated)
        {
            await _categoryService.UpdateAsync(updated);
            return RedirectToAction(nameof(Index));
           
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var deletedCategory= _categoryService.FindById(id);
            if (deletedCategory == null)
            {
                return RedirectToAction("Index");
            }
            return View(deletedCategory);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Category category)
        {
            await _categoryService.DeleteAsync(category.ID);
            return RedirectToAction("Index");
        }

    }
}
