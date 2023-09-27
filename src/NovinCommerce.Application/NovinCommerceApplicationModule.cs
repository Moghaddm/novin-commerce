using NovinCm.ProductManagement;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace NovinCommerce;

[DependsOn(
    typeof(NovinCommerceDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(NovinCommerceApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
)]
[DependsOn(typeof(ProductManagementApplicationModule))]
public class NovinCommerceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<NovinCommerceApplicationModule>(); });

        Configure<AbpSequentialGuidGeneratorOptions>(options =>
        {
            options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsBinary;
        });
    }
}