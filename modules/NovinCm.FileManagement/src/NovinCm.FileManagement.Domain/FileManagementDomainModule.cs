using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace NovinCm.FileManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(FileManagementDomainSharedModule)
)]
public class FileManagementDomainModule : AbpModule
{

}
