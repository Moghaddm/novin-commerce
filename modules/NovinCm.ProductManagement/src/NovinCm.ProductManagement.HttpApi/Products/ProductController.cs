using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovinCm.ProductManagement.Models.Products;
using NovinCommerce.Services.Products;
using Volo.Abp;

namespace NovinCm.ProductManagement.Products;

[Area(ProductManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = ProductManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/ProductManagement/product")]
public class ProductController : ProductManagementController, IProductAppService
{
    private readonly IProductAppService _productAppService;

    public ProductController(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    [HttpPost("{companyId:guid}", Name = "CreateProduct")]
    public async Task<ProductCreateUpdateDto> CreateAsync(Guid companyId, ProductCreateUpdateDto productInput)
    {
        return await _productAppService.CreateAsync(companyId, productInput);
    }

    [HttpGet]
    public async ValueTask<IEnumerable<ProductDetailsDto>> GetAllAsync()
    {
        return await _productAppService.GetAllAsync();
    }

    [HttpGet("{productId:guid}", Name = "GetByIdProduct")]
    public ValueTask<ProductDetailsDto> GetByIdAsync(Guid productId)
    {
        return _productAppService.GetByIdAsync(productId);
    }

    [HttpDelete("{productId:guid}", Name = "DeleteProduct")]
    public Task DeleteAsync(Guid productId)
    {
        return _productAppService.DeleteAsync(productId);
    }

    [HttpPut("{productId:guid}", Name = "UpdateProduct")]
    public Task UpdateAsync(Guid productId, ProductCreateUpdateDto inputProduct)
    {
        return _productAppService.UpdateAsync(productId, inputProduct);
    }
}