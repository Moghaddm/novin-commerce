using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovinCommerce.Data;
using Volo.Abp.DependencyInjection;

namespace NovinCommerce.EntityFrameworkCore;

public class EntityFrameworkCoreNovinCommerceDbSchemaMigrator
    : INovinCommerceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNovinCommerceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the NovinCommerceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NovinCommerceDbContext>()
            .Database
            .MigrateAsync();
    }
}