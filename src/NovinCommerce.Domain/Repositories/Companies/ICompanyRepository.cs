using NovinCommerce.Entities.Categories;
using NovinCommerce.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Repositories.Companies
{
    public interface ICompanyRepository : IBasicRepository<Company>
    {
        Task<Company> GetByIdAsync(Guid id);
    }
}
