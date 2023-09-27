using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovinCm.ProductManagement.Models.Products;
using NovinCm.ProductManagement.Services.Products;
using Volo.Abp;

namespace NovinCm.ProductManagement.Products;

[Area(ProductManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = ProductManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/ProductManagement/category")]
public class CategoryController : ProductManagementController, ICategoryAppService
{
    private readonly ICategoryAppService _categoryAppService;

    public CategoryController(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    [HttpPost(Name = "CreateCategory")]
    public async Task<CategoryDto> CreateAsync(CategoryDto inputCategory)
    {
        return await _categoryAppService.CreateAsync(inputCategory);
    }

    [HttpGet]
    public async ValueTask<IEnumerable<CategoryDto>> GetAllAsync()
    {
        return await _categoryAppService.GetAllAsync();
    }

    [HttpGet("{categoryId}", Name = "GetByIdCategory")]
    public async ValueTask<CategoryDto> GetByIdAsync(Guid categoryId)
    {
        return await _categoryAppService.GetByIdAsync(categoryId);
    }

    [HttpDelete("{categoryId}", Name = "DeleteCategory")]
    public async Task DeleteAsync(Guid categoryId)
    {
        await _categoryAppService.DeleteAsync(categoryId);
    }

    [HttpPut("{categoryId}", Name = "UpdateCategory")]
    public async Task UpdateAsync(Guid categoryId, CategoryDto inputCategory)
    {
        await _categoryAppService.UpdateAsync(categoryId, inputCategory);
    }
}