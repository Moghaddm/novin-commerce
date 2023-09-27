using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NovinCm.ProductManagement.Models.Products;
using Volo.Abp.Application.Services;

namespace NovinCm.ProductManagement.Services.Products;

public interface ICategoryAppService : IApplicationService
{
    Task<CategoryDto> CreateAsync(CategoryDto inputCategory);
    ValueTask<IEnumerable<CategoryDto>> GetAllAsync();
    ValueTask<CategoryDto> GetByIdAsync(Guid categoryId);
    Task DeleteAsync(Guid categoryId);
    Task UpdateAsync(Guid categoryId, CategoryDto inputCategory);
}