using Volo.Abp.Modularity;

namespace NovinCommerce;

[DependsOn(
    typeof(NovinCommerceApplicationModule),
    typeof(NovinCommerceDomainTestModule)
)]
public class NovinCommerceApplicationTestModule : AbpModule
{
}