using NovinCommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace NovinCommerce;

[DependsOn(
    typeof(NovinCommerceEntityFrameworkCoreTestModule)
    )]
public class NovinCommerceDomainTestModule : AbpModule
{

}
