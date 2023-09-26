using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace NovinCm.FileManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(FileManagementBlazorModule)
    )]
public class FileManagementBlazorServerModule : AbpModule
{

}
