using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovinCommerce.Entities.Companies;
using NovinCommerce.EntityFrameworkCore;
using NovinCommerce.Repositories.Companies;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NovinCommerce.Repositories;

public class CompanyRepository : EfCoreRepository<NovinCommerceDbContext, Company, Guid>, ICompanyRepository
{
    public CompanyRepository(IDbContextProvider<NovinCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Company> GetByIdAsync(Guid id)
    {
        var dbset = await GetDbSetAsync();

        var company = await dbset.FirstOrDefaultAsync(c => c.Id == id);

        return company!;
    }
}