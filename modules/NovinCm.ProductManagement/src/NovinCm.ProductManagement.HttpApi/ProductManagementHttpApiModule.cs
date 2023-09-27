﻿using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using NovinCm.ProductManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace NovinCm.ProductManagement;

[DependsOn(
    typeof(ProductManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ProductManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ProductManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}