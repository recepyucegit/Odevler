using Application.DTOs.SupplierDTOs;
using Application.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierServiceManager _supplierServiceManager;

        public SupplierController(SupplierServiceManager supplierServiceManager)
        {
            _supplierServiceManager = supplierServiceManager;
        }

        [HttpGet("suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _supplierServiceManager.GetSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpGet("get-supplier")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplier = await _supplierServiceManager.GetSupplier(id);
            return Ok(supplier);
        }

        [HttpPost("add-supplier")]
        public async Task<IActionResult> PostSupplier([FromForm] CreateSupplierDTO supplierDTO)
        {
            var createdSupplier = await _supplierServiceManager.AddSupplier(supplierDTO);
            return Ok(createdSupplier);
        }


        [HttpPut("update-supplier")]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDTO updateSupplierDto)
        {
            await _supplierServiceManager.UpdateSupplier(updateSupplierDto);
            return Ok();
        }

        [HttpDelete("delete-supplier")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var deletedSupplier = await _supplierServiceManager.GetSupplier(id);
            if (deletedSupplier != null)
            {
                await _supplierServiceManager.DeleteSupplier(deletedSupplier);
                return Ok("Tedarikçi Silindi!");
            }
            else
            {
                return BadRequest("Tedarikçi bulunamadı!");
            }
        }
    }
}