using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovinCommerce.Entities.Categories;
using NovinCommerce.EntityFrameworkCore;
using NovinCommerce.Repositories.Products;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NovinCommerce.Repositories;

public class CategoryRepository : EfCoreRepository<NovinCommerceDbContext, Category, Guid>, ICategoryRepository
{
    public CategoryRepository(IDbContextProvider<NovinCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        var dbset = await GetDbSetAsync();

        var cateogry = await dbset.FirstOrDefaultAsync(c => c.Id == id);

        return cateogry!;
    }
}