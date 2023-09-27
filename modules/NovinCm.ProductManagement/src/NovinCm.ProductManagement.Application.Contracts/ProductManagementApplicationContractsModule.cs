using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace NovinCm.ProductManagement;

[DependsOn(
    typeof(ProductManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class ProductManagementApplicationContractsModule : AbpModule
{
}