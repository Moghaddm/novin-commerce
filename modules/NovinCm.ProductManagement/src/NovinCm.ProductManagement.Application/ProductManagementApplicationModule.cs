using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace NovinCm.ProductManagement;

[DependsOn(
    typeof(ProductManagementDomainModule),
    typeof(ProductManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
)]
public class ProductManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ProductManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<ProductManagementApplicationModule>(true); });
    }
}