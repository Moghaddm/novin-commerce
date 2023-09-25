using NovinCommerce.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NovinCommerce.Services.Companies
{
    public interface ICompanyAppService : IApplicationService
    {
        Task<CompanyDto> CreateAsync(CompanyDto inputCompany);
        ValueTask<IEnumerable<CompanyDto>> GetAllAsync();
        ValueTask<CompanyDto> GetByIdAsync(Guid companyId);
        Task DeleteAsync(Guid companyId);
        Task UpdateAsync(Guid companyId, CompanyDto inputCompany);
    }
}
