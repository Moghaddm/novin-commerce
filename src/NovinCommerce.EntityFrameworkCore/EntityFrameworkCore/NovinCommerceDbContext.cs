using Microsoft.EntityFrameworkCore;
using NovinCommerce.Entities.Categories;
using NovinCommerce.Entities.Companies;
using NovinCommerce.Entities.Products;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using NovinCm.ProductManagement.EntityFrameworkCore;
using NovinCm.FileManagement.EntityFrameworkCore;

namespace NovinCommerce.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class NovinCommerceDbContext :
    AbpDbContext<NovinCommerceDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Company> Companies { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public NovinCommerceDbContext(DbContextOptions<NovinCommerceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */


        /* Product Configuration */
        builder.Entity<Product>(p =>
        {
            p.ToTable("Products");
            p.HasKey(p => p.Id);
            p.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Product>().HasOne(p => p.Company).WithMany().HasForeignKey("CompanyId");

        /* Category Configuration */
        builder.Entity<Category>(c =>
        {
            c.ToTable("Category");
            c.HasKey(c => c.Id);
            c.Property(c => c.Name).IsRequired();
        });

        builder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey("CategoryId");

        /* Company Configuration */
        builder.Entity<Company>(c =>
        {
            c.ToTable("Companies");
            c.HasKey(c => c.Id);
            c.Property(c => c.Title).IsRequired();
        });


        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(NovinCommerceConsts.DbTablePrefix + "YourEntities", NovinCommerceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
            builder.ConfigureProductManagement();
            builder.ConfigureFileManagement();
        }
}
