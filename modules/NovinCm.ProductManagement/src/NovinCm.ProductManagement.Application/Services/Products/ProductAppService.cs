using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NovinCm.ProductManagement.Models.Products;
using NovinCm.ProductManagement.Permissions;
using NovinCommerce.Entities.Products;
using NovinCommerce.Products;
using NovinCommerce.Repositories.Companies;
using NovinCommerce.Repositories.Products;
using Volo.Abp.Application.Services;

namespace NovinCommerce.Services.Products;

[Authorize(ProductManagementPermissions.Products.Default)]
public class ProductAppService : ApplicationService, IProductAppService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IProductRepository _productRepository;

    public ProductAppService(IProductRepository productRepository, ICategoryRepository categoryRepository,
        ICompanyRepository companyRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _companyRepository = companyRepository;
    }

    [Authorize(ProductManagementPermissions.Products.Create)]
    public async Task<ProductCreateUpdateDto> CreateAsync(Guid companyId, ProductCreateUpdateDto productInput)
    {
        var company = await _companyRepository.GetByIdAsync(companyId);

        var category = await _categoryRepository.GetByIdAsync(productInput.CategoryId);

        var product = new Product(
            productInput.Name,
            productInput.Description,
            productInput.Price,
            productInput.Quantity,
            ProductStockState.InStock,
            category,
            company);

        await _productRepository.InsertAsync(product);

        return productInput;
    }

    [Authorize(ProductManagementPermissions.Products.Delete)]
    public async Task DeleteAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        await _productRepository.DeleteAsync(product);
    }

    public async ValueTask<IEnumerable<ProductDetailsDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        var productsOutput = products.Select(p => new ProductDetailsDto
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Quantity = p.Quantity,
            Company = new CompanyDetailsDto { Title = p.Company.Title, Description = p.Company.Description }
        }).ToList();

        return productsOutput;
    }

    public async ValueTask<ProductDetailsDto> GetByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        var productOutput = new ProductDetailsDto
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            Company = new CompanyDetailsDto { Title = product.Company.Title, Description = product.Company.Description }
        };

        return productOutput;
    }

    [Authorize(ProductManagementPermissions.Products.Edit)]
    public async Task UpdateAsync(Guid productId, ProductCreateUpdateDto inputProduct)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        product.UpdateProduct(inputProduct.Name, inputProduct.Description, inputProduct.Price, inputProduct.Quantity);
    }
}