using Volo.Abp.Modularity;

namespace NovinCm.FileManagement;

[DependsOn(
    typeof(FileManagementApplicationModule),
    typeof(FileManagementDomainTestModule)
    )]
public class FileManagementApplicationTestModule : AbpModule
{

}
