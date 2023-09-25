using NovinCommerce.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Repositories.Products
{
    public interface IProductRepository : IBasicRepository<Product>
    {
        ValueTask<IEnumerable<Product>> GetByCategoryTypeAsync(string categoryName);
        ValueTask<Product> GetByIdAsync(Guid productId);
        ValueTask<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByNameAsync(IEnumerable<Product> products, string name);
    }
}
