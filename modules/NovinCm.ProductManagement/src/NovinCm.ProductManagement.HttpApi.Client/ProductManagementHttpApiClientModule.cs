using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace NovinCm.ProductManagement;

[DependsOn(
    typeof(ProductManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ProductManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ProductManagementApplicationContractsModule).Assembly,
            ProductManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProductManagementHttpApiClientModule>();
        });
    }
}
