using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NovinCommerce.Companies;
using NovinCommerce.Entities.Companies;
using NovinCommerce.Models.Companies;
using NovinCommerce.Permissions;
using NovinCommerce.Repositories.Companies;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities.Caching;
using Volo.Abp.Domain.Repositories;

namespace NovinCommerce.Services.Companies;

[Authorize(NovinCommercePermissions.Companies.Default)]
public class CompanyAppService : ApplicationService, ICompanyAppService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IEntityCache<Company, Guid> _companyCache;
    private readonly CompanyInputDtoMapper _companyInputDtoMapper;
    private readonly CompanyOutputDtoMapper _companyOutputDtoMapper;
    private readonly CompanyListOutputDtoMapper _companyListOutputDtoMapper;

    public CompanyAppService(
        ICompanyRepository companyRepository,
        IEntityCache<Company, Guid> companyCache,
        CompanyOutputDtoMapper companyOutputDtoMapper,
            CompanyInputDtoMapper companyInputDtoMapper,
        CompanyListOutputDtoMapper companyListOutputDtoMapper)
    {
        _companyCache = companyCache;
        _companyRepository = companyRepository;
        _companyInputDtoMapper = companyInputDtoMapper;
        _companyOutputDtoMapper = companyOutputDtoMapper;
        _companyListOutputDtoMapper = companyListOutputDtoMapper;
    }

    [Authorize(NovinCommercePermissions.Companies.Create)]
    public async Task<CompanyDto> CreateAsync(CompanyDto inputCompany)
    {
        var company = _companyInputDtoMapper.Map(inputCompany);

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

        companies = companies ?? await _companyRepository.GetListAsync();

        var outputCompanies = _companyListOutputDtoMapper.Map(companies);

        return outputCompanies;
    }

    public async ValueTask<CompanyDto> GetByIdAsync(Guid companyId)
    {
        var company = await _companyCache.GetAsync(companyId);

        company = company ?? await _companyRepository.GetByIdAsync(companyId);

        var outputCompany = _companyOutputDtoMapper.Map(company);

        return outputCompany;
    }

    [Authorize(NovinCommercePermissions.Companies.Edit)]
    public async Task UpdateAsync(Guid companyId, CompanyDto inputCompany)
    {
        var company = await _companyRepository.GetByIdAsync(companyId);

        company.Update(inputCompany.Title, inputCompany.Description);
    }
}