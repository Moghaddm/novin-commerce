using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NovinCm.ProductManagement.Models.Products;
using Volo.Abp.Application.Services;

namespace NovinCommerce.Services.Products;

public interface IProductAppService : IApplicationService
{
    Task<ProductCreateUpdateDto> CreateAsync(Guid companyId, ProductCreateUpdateDto productInput);
    ValueTask<IEnumerable<ProductDetailsDto>> GetAllAsync();
    ValueTask<ProductDetailsDto> GetByIdAsync(Guid productId);
    Task DeleteAsync(Guid productId);
    Task UpdateAsync(Guid productId, ProductCreateUpdateDto inputProduct);
}