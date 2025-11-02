using Application.DTOs.ProductDTOs;
using Application.Repositories;
using Domain.Entities;

namespace Application.ServiceManager
{
    public class ProductServiceManager
    {
        private readonly IProductRepository _productRepository;

        public ProductServiceManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.ID,
                ProductName = p.Name,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                Description = p.Description,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId
            }).ToList();
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null) return null;

                return new ProductDTO
                {
                    Id = product.ID,
                    ProductName = product.Name,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    SupplierId = product.SupplierId
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AddProduct(CreateProductDTO dto)
        {
            try
            {
                var product = new Product
                {
                    Name = dto.ProductName,
                    UnitPrice = dto.UnitPrice,
                    UnitsInStock = dto.UnitsInStock,
                    Description = dto.Description,
                    CategoryId = dto.CategoryId,
                    SupplierId = dto.SupplierId
                };

                await _productRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateProduct(UpdateProductDTO dto)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(dto.Id);
                if (existingProduct == null)
                    throw new Exception("Ürün bulunamadı!");

                existingProduct.Name = dto.ProductName;
                existingProduct.UnitPrice = dto.UnitPrice;
                existingProduct.UnitsInStock = dto.UnitsInStock;
                existingProduct.Description = dto.Description;
                existingProduct.CategoryId = dto.CategoryId;
                existingProduct.SupplierId = dto.SupplierId;

                await _productRepository.UpdateAsync(existingProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task DeleteProduct(ProductDTO dto)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(dto.Id);
                if (product != null)
                {
                    await _productRepository.DeleteAsync(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
