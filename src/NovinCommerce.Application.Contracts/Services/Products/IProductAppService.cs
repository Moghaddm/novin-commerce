using NovinCommerce.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovinCommerce.Services.Products
{
    public interface IProductAppService
    {
        ValueTask<ProductCreateDto> CreateAsync(ProductCreateDto productCreateDto);
    }
}
