using NovinCommerce.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Repositories.Products
{
    public interface ICategoryRepository : IRepository<Category,Guid>
    {
       Task<Category> GetByIdAsync(Guid id);
    }
}
