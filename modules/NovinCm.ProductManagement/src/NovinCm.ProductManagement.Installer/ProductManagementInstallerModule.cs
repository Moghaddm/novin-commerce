using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace NovinCm.ProductManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ProductManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProductManagementInstallerModule>();
        });
    }
}
