using NovinCommerce.Entities.Categories;
using NovinCommerce.EntityFrameworkCore;
using NovinCommerce.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NovinCommerce.Repositories
{
    public class CategoryRepository : EfCoreRepository<NovinCommerceDbContext,Category,Guid>,ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<NovinCommerceDbContext> dbContextProvider) : base(dbContextProvider) { }

        public Task<Category> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
