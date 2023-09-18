using NovinCommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace NovinCommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NovinCommerceEntityFrameworkCoreModule),
    typeof(NovinCommerceApplicationContractsModule)
    )]
public class NovinCommerceDbMigratorModule : AbpModule
{
}
