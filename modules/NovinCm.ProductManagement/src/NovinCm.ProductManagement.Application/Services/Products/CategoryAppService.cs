using Microsoft.AspNetCore.Authorization;
using NovinCommerce.Entities.Categories;
using NovinCommerce.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovinCm.ProductManagement.Models.Products;
using NovinCm.ProductManagement.Permissions;
using NovinCm.ProductManagement.Services.Products;
using Volo.Abp.Application.Services;

namespace NovinCommerce.Services.Products
{
    [Authorize(ProductManagementPermissions.Categories.Default)]
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        [Authorize(ProductManagementPermissions.Categories.Create)]
        public async Task<CategoryDto> CreateAsync(CategoryDto inputCategory)
        {
            var category = new Category(inputCategory.Name, inputCategory.Description);

            await _categoryRepository.InsertAsync(category);

            return inputCategory;
        }

        [Authorize(ProductManagementPermissions.Categories.Delete)]
        public async Task DeleteAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            await _categoryRepository.DeleteAsync(category);
        }

        public async ValueTask<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetListAsync();

            var outputCategories = categories.Select(c => new CategoryDto { Name = c.Name, Description = c.Description }).ToList();

            return outputCategories;
        }

        public async ValueTask<CategoryDto> GetByIdAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            var outputCategory = new CategoryDto { Name = category.Name, Description = category.Description };

            return outputCategory;
        }

        [Authorize(ProductManagementPermissions.Categories.Edit)]
        public async Task UpdateAsync(Guid categoryId, CategoryDto inputCategory)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            category.Update(inputCategory.Name, inputCategory.Description);
        }
    }
}
