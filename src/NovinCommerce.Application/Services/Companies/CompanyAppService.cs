using Microsoft.AspNetCore.Authorization;
using NovinCommerce.Entities.Companies;
using NovinCommerce.Models.Companies;
using NovinCommerce.Repositories.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovinCommerce.Permissions;
using Volo.Abp.Application.Services;

namespace NovinCommerce.Services.Companies
{
    [Authorize(NovinCommercePermissions.Companies.Default)]
    public class CompanyAppService : ApplicationService, ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyAppService(ICompanyRepository companyRepository) => _companyRepository = companyRepository;

        [Authorize(NovinCommercePermissions.Companies.Create)]
        public async Task<CompanyDto> CreateAsync(CompanyDto inputCompany)
        {
            var company = new Company(inputCompany.Title, inputCompany.Description);

            await _companyRepository.InsertAsync(company);

            return inputCompany;
        }

        [Authorize(NovinCommercePermissions.Companies.Delete)]
        public async Task DeleteAsync(Guid companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);

            await _companyRepository.DeleteAsync(company);
        }

        public async ValueTask<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var companies = await _companyRepository.GetListAsync();

            var outputCompanies = companies.Select<Company, CompanyDto>(c => new CompanyDto { Title = c.Title, Description = c.Description });

            return outputCompanies;
        }

        public async ValueTask<CompanyDto> GetByIdAsync(Guid companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);

            var outputCompany = new CompanyDto { Title = company.Title, Description = company.Description };

            return outputCompany;
        }

        [Authorize(NovinCommercePermissions.Companies.Edit)]
        public async Task UpdateAsync(Guid companyId, CompanyDto inputCompany)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);

            company.Update(inputCompany.Title, inputCompany.Description);
        }
    }
}
