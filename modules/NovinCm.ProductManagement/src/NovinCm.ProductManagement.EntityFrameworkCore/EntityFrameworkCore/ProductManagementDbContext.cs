using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace NovinCm.ProductManagement.EntityFrameworkCore;

[ConnectionStringName(ProductManagementDbProperties.ConnectionStringName)]
public class ProductManagementDbContext : AbpDbContext<ProductManagementDbContext>, IProductManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProductManagement();
    }
}