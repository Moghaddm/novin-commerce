using System;
using System.Threading.Tasks;
using NovinCommerce.Entities.Categories;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Repositories.Products;

public interface ICategoryRepository : IRepository<Category, Guid>
{
    Task<Category> GetByIdAsync(Guid id);
}