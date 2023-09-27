using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovinCommerce.Entities.Products;
using NovinCommerce.EntityFrameworkCore;
using NovinCommerce.Repositories.Products;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NovinCommerce.Repositories;

public class ProductRepository : EfCoreRepository<NovinCommerceDbContext, Product, Guid>, IProductRepository
{
    public ProductRepository(IDbContextProvider<NovinCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async ValueTask<IEnumerable<Product>> GetByCategoryTypeAsync(string categoryName)
    {
        var dbset = await GetDbSetAsync();

        return await dbset.Where(p => p.Category.Name == categoryName).ToListAsync();
    }

    public async ValueTask<Product> GetByIdAsync(Guid productId)
    {
        var dbset = await GetDbSetAsync();

        var product = await dbset.Include(p => p.Company).FirstOrDefaultAsync(p => p.Id == productId);

        return product!;
    }

    public async ValueTask<IEnumerable<Product>> GetAllAsync()
    {
        var dbset = await GetDbSetAsync();

        var products = await dbset.Include(p => p.Company).ToListAsync();

        return products;
    }

    public async Task<Product> GetByNameAsync(IEnumerable<Product> products, string name)
    {
        var dbset = await GetDbSetAsync();

        var product = await dbset.FirstOrDefaultAsync(p => p.Name == name);

        return product!;
    }
}