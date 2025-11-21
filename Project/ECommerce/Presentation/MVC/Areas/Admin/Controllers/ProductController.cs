using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using DAL.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductServiceManager _productService;
        private readonly ICategoryServiceManager _categoryService;

        public ProductController(IProductServiceManager productService, ICategoryServiceManager categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            return View(_productService.GetAll().OrderByDescending(x => x.ID));
        }

        //Ürün oluşturma sayfası
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetActives().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()

            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            //parametre olarak alınan product nesnesini veritabanına eklemek için _productService'i kullan.
            await _productService.CreateAsync(product);
            return View();
        }
        //todo:  Ürün güncelleme sayfası

        //burada product id'ye göre ürünü bulup güncelleme işlemi yapılacak.
        public ActionResult Update(int id)
        {
            var updateProduct = _productService.FindById(id);
            if (updateProduct == null)
            {
                return RedirectToAction("Index");
            }

            // Kategori listesini ViewBag ile gönder - SelectList olarak
            ViewBag.Categories = new SelectList(
                _categoryService.GetActives(),
                "ID",
                "CategoryName",
                updateProduct.CategoryId
            );

            return View(updateProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(Product updated)
        {
            // Category navigation property'si için validation'ı kaldır
            ModelState.Remove("Category");
            updated.Category = null;

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(
                    _categoryService.GetActives(),
                    "ID",
                    "CategoryName",
                    updated.CategoryId
                );
                return View(updated);
            }

            // ModifiedDate ve ModifiedComputerName güncelle
            updated.ModifiedDate = DateTime.Now;
            updated.ModifiedComputerName = System.Environment.MachineName;

            await _productService.UpdateAsync(updated);

            // Başarılı güncelleme mesajı
            TempData["SuccessMessage"] = "Product updated successfully!";

            return RedirectToAction(nameof(Index));
        }


        //todo: Ürün silme
        public async Task<ActionResult> Delete(int id)
        {
            var deletedProduct = _productService.FindById(id);
            if (deletedProduct == null)
            {
                return RedirectToAction("Index");
            }
            return View(deletedProduct);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Product product)
        {
            await _productService.DeleteAsync(product.ID);
            return RedirectToAction("Index");
        }
    }
}
