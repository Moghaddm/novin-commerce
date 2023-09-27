using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NovinCommerce.Entities.Products;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Repositories.Products;

public interface IProductRepository : IBasicRepository<Product>
{
    ValueTask<IEnumerable<Product>> GetByCategoryTypeAsync(string categoryName);
    ValueTask<Product> GetByIdAsync(Guid productId);
    ValueTask<IEnumerable<Product>> GetAllAsync();

    Task<Product> GetByNameAsync(IEnumerable<Product> products, string name);
}