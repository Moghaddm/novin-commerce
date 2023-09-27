namespace NovinCm.ProductManagement;

public static class ProductManagementDbProperties
{
    public const string ConnectionStringName = "ProductManagement";
    public static string DbTablePrefix { get; set; } = "ProductManagement";

    public static string? DbSchema { get; set; } = null;
}