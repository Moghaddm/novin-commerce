using NovinCommerce.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NovinCommerce.Services.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductCreateUpdateDto> CreateAsync(ProductCreateUpdateDto productInput, Guid categoryId, Guid companyId);
        ValueTask<IEnumerable<ProductDetailsDto>> GetAllAsync();
        ValueTask<ProductDetailsDto> GetByIdAsync(Guid productId);
        Task DeleteAsync(Guid productId);
        Task UpdateAsync(Guid productId,ProductCreateUpdateDto inputProduct);
    }
}
