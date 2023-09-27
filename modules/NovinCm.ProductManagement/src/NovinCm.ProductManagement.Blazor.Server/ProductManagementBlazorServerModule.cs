using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace NovinCm.ProductManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(ProductManagementBlazorModule)
)]
public class ProductManagementBlazorServerModule : AbpModule
{
}