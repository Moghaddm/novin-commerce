using Volo.Abp.Modularity;

namespace NovinCm.ProductManagement;

[DependsOn(
    typeof(ProductManagementApplicationModule),
    typeof(ProductManagementDomainTestModule)
    )]
public class ProductManagementApplicationTestModule : AbpModule
{

}
