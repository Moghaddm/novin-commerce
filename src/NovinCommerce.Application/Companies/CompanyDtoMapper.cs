using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using NovinCommerce.Entities.Companies;
using NovinCommerce.Models.Companies;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;

namespace NovinCommerce.Companies
{
    public class CompanyListOutputDtoMapper : IObjectMapper<List<Company>, List<CompanyDto>>, ITransientDependency
    {
        public List<CompanyDto> Map(List<Company> source) =>
            source.Select(c => new CompanyDto { Title = c.Title, Description = c.Description }).ToList();

        public List<CompanyDto> Map(List<Company> source, List<CompanyDto> destination)
        {
            destination = source.Select(c => new CompanyOutputDtoMapper().Map(c)).ToList();

            return destination;
        }
    }

    public class CompanyOutputDtoMapper : IObjectMapper<Company, CompanyDto>, ITransientDependency
    {
        public CompanyDto Map(Company source)
            => new CompanyDto { Title = source.Title, Description = source.Description };

        public CompanyDto Map(Company source, CompanyDto destination)
        {
            destination.Title = source.Title;
            destination.Description = source.Description;

            return destination;
        }
    }

    public class CompanyInputDtoMapper : IObjectMapper<CompanyDto, Company>, ITransientDependency
    {
        public Company Map(CompanyDto source) => new Company(source.Title, source.Description);

        public Company Map(CompanyDto source, Company destination)
        {
            destination.Update(source.Title, source.Description);

            return destination;
        }
    }
}
