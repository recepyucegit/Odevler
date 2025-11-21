using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Abstracts;
using DAL.Entities.Concretes;
using API.DTOs;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    //[AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceManager _productService;
        private readonly ICategoryServiceManager _categoryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(
            IProductServiceManager productService,
            ICategoryServiceManager categoryService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/product
        [HttpGet]
        [AllowAnonymous] // Herkes ürünleri listeleyebilir
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productService.GetActives()
                    .ToList()
                    .Select(p => new ProductDTO
                    {
                        ID = p.ID,
                        ProductName = p.ProductName,
                        Description = p.Description,
                        UnitPrice = p.Price,
                        UnitsInStock = p.Stock,
                        CategoryId = p.CategoryId,
                        CategoryName = _categoryService.FindById(p.CategoryId)?.CategoryName,
                    })
                    .OrderByDescending(x => x.ID)
                    .ToList();

                return Ok(new ApiResponse<List<ProductDTO>>
                {
                    Success = true,
                    Message = "Ürünler başarıyla listelendi",
                    Data = products
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürünler listelenirken hata oluştu");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Sunucu hatası oluştu"
                });
            }
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _productService.FindById(id);
                if (product == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Ürün bulunamadı"
                    });
                }

                var productDto = new ProductDTO
                {
                    ID = product.ID,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    UnitPrice = product.Price,
                    UnitsInStock = product.Stock,
                    CategoryId = product.CategoryId,
                    CategoryName = _categoryService.FindById(product.CategoryId)?.CategoryName
                };

                return Ok(new ApiResponse<ProductDTO>
                {
                    Success = true,
                    Message = "Ürün detayı getirildi",
                    Data = productDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün detayı getirilirken hata oluştu");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Sunucu hatası oluştu"
                });
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanAddProduct")]
        public async Task<IActionResult> PostProduct([FromBody] CreateProductDTO productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Geçersiz veri",
                        Data = ModelState
                    });
                }

                //  Supplier ID'yi token'dan al
                var supplierIdClaim = User.FindFirst("SupplierId")?.Value;

                if (string.IsNullOrEmpty(supplierIdClaim) || !int.TryParse(supplierIdClaim, out int supplierId))
                {
                    return Unauthorized(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Supplier bilgisi bulunamadı"
                    });
                }

                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    Description = productDto.Description,
                    Price = productDto.UnitPrice,
                    Stock = productDto.UnitsInStock,
                    CategoryId = productDto.CategoryId,
                    SupplierId = supplierId  
                };

                await _productService.CreateAsync(product);

                _logger.LogInformation($"Ürün eklendi. ID: {product.ID}, Supplier: {supplierId}");

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Ürün başarıyla eklendi",
                    Data = new { ProductId = product.ID }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün eklenirken hata");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Sunucu hatası: " + ex.Message
                });
            }
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        [Authorize(Policy = "CanEditProduct")]
        //[AllowAnonymous]
        public async Task<IActionResult> PutProduct(int id, [FromBody] UpdateProductDTO productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Geçersiz veri",
                        Data = ModelState
                    });
                }

                var existingProduct = _productService.FindById(id);
                if (existingProduct == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Güncellenecek ürün bulunamadı"
                    });
                }

                existingProduct.ProductName = productDto.ProductName;
                existingProduct.Description = productDto.Description;
                existingProduct.Price = productDto.UnitPrice;
                existingProduct.Stock = productDto.UnitsInStock;
                existingProduct.CategoryId = productDto.CategoryId;

                await _productService.UpdateAsync(existingProduct);

                var supplierName = User.FindFirst(ClaimTypes.Name)?.Value;
                _logger.LogInformation($"Ürün güncellendi. Supplier: {supplierName}, Ürün ID: {id}");

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Ürün başarıyla güncellendi"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ürün güncellenirken hata oluştu. ID: {id}");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Ürün güncellenirken hata oluştu"
                });
            }
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDeleteProduct")]
        //[AllowAnonymous]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = _productService.FindById(id);
                if (product == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Silinecek ürün bulunamadı"
                    });
                }

                await _productService.DeleteAsync(id);

                var supplierName = User.FindFirst(ClaimTypes.Name)?.Value;
                _logger.LogInformation($"Ürün silindi. Supplier: {supplierName}, Ürün: {product.ProductName}");

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Ürün başarıyla silindi"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ürün silinirken hata oluştu. ID: {id}");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Ürün silinirken hata oluştu"
                });
            }
        }

        // GET: api/product/categories
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _categoryService.GetActives()
                    .Select(c => new CategoryDTO
                    {
                        ID = c.ID,
                        CategoryName = c.CategoryName,
                        Description = c.Description
                    })
                    .ToList();

                return Ok(new ApiResponse<List<CategoryDTO>>
                {
                    Success = true,
                    Message = "Kategoriler listelendi",
                    Data = categories
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategoriler listelenirken hata oluştu");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Sunucu hatası oluştu"
                });
            }
        }
    }
}