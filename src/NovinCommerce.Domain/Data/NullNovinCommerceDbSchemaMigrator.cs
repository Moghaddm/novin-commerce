using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NovinCommerce.Data;

/* This is used if database provider does't define
 * INovinCommerceDbSchemaMigrator implementation.
 */
public class NullNovinCommerceDbSchemaMigrator : INovinCommerceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}