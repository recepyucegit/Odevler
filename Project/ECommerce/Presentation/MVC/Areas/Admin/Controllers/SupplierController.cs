using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly ISupplierServiceManager _supplierService;

        public SupplierController(ISupplierServiceManager supplierService)
        {
            _supplierService = supplierService;
        }

        // List
        public IActionResult Index()
        {
            var suppliers = _supplierService.GetAll().ToList();
            return View(suppliers);
        }

        // Create GET
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.CreateAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // Update GET
        public IActionResult Update(int id)
        {
            var supplier = _supplierService.FindById(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        // Update POST
        [HttpPost]
        public async Task<IActionResult> Update(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.UpdateAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // DELETE GET - Silme onay sayfası
        public IActionResult Delete(int id)
        {
            var supplier = _supplierService.FindById(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        // DELETE POST - Silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supplierService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}