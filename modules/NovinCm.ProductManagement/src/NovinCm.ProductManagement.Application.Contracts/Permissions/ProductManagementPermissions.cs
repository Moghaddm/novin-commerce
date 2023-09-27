using Volo.Abp.Reflection;

namespace NovinCm.ProductManagement.Permissions;

public class ProductManagementPermissions
{
    public const string GroupProductManagementName = "ProductManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductManagementPermissions));
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Products
    {
        public const string Default = GroupProductManagementName + ".Products";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Categories
    {
        public const string Default = GroupProductManagementName + ".Categories";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}