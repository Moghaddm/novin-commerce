using System.Threading.Tasks;

namespace NovinCommerce.Data;

public interface INovinCommerceDbSchemaMigrator
{
    Task MigrateAsync();
}