using Application.DTOs.CategoryDTOs;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceManager
{
    public class CategoryServiceManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServiceManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories=await _categoryRepository.GetAllAsync();
           var categoriesDto= categories.Select(x => new CategoryDTO
            {
                Id = x.ID,
                CategoryName = x.Name,
                Description = x.Description
            }).ToList();

            return categoriesDto;
        }

        public async Task AddCategory(CreateCategoryDTO categoryDTO)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryDTO.CategoryName,
                    Description = categoryDTO.Description
                };



                await _categoryRepository.AddAsync(category);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                if (updateCategoryDto.Id >0)
                {
                    //Entity dönüşüm
                    var updated = new Category
                    {
                        ID = updateCategoryDto.Id,
                        Name = updateCategoryDto.CategoryName,
                        Description = updateCategoryDto.Description
                    };



                    await _categoryRepository.UpdateAsync(updated);
                }




                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(categoryDTO.Id);
                await _categoryRepository.DeleteAsync(category);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            try
            {
                var category=await _categoryRepository.GetByIdAsync(id);
                return new CategoryDTO
                {
                    Id = category.ID,
                    CategoryName = category.Name,
                    Description = category.Description
                };

            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
