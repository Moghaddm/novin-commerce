using Localization.Resources.AbpUi;
using NovinCommerce.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using NovinCm.ProductManagement;
using Volo.Abp.AspNetCore.Mvc;
using NovinCm.FileManagement;

namespace NovinCommerce;

[DependsOn(
    typeof(NovinCommerceApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
[DependsOn(typeof(ProductManagementHttpApiModule))]
    [DependsOn(typeof(FileManagementHttpApiModule))]
    public class NovinCommerceHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();

        //Configure<AbpAspNetCoreMvcOptions>(options =>
        //{
        //    options
        //        .ConventionalControllers
        //        .Create(typeof(ProductManagementAppService).Assembly, opt =>
        //        {
        //            opt.RootPath = "ProductManagement";
        //        });
        //});
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<NovinCommerceResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
