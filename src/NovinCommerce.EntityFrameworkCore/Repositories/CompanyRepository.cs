using NovinCommerce.Entities.Companies;
using NovinCommerce.EntityFrameworkCore;
using NovinCommerce.Repositories.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace NovinCommerce.Repositories
{
    public class CompanyRepository : EfCoreRepository<NovinCommerceDbContext, Company, Guid>, ICompanyRepository
    {
        public Task<Company> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
