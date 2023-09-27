using System;
using System.Threading.Tasks;
using NovinCommerce.Entities.Companies;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Repositories.Companies;

public interface ICompanyRepository : IBasicRepository<Company>
{
    Task<Company> GetByIdAsync(Guid id);
}