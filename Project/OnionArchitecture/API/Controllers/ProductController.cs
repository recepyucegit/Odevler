using Application.DTOs.ProductDTOs;
using Application.ServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServiceManager _productServiceManager;

        public ProductController(ProductServiceManager productServiceManager)
        {
            _productServiceManager = productServiceManager;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productServiceManager.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("get-product")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productServiceManager.GetProduct(id);
            if (product == null)
                return NotFound("Ürün bulunamadı!");
            return Ok(product);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] CreateProductDTO dto)
        {
            await _productServiceManager.AddProduct(dto);
            return Ok("Ürün eklendi!");
        }


        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO dto)
        {
            await _productServiceManager.UpdateProduct(dto);
            return Ok("Ürün güncellendi!");
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productServiceManager.GetProduct(id);
            if (product == null)
                return BadRequest("Ürün bulunamadı!");

            await _productServiceManager.DeleteProduct(product);
            return Ok("Ürün silindi!");
        }
    }
}
