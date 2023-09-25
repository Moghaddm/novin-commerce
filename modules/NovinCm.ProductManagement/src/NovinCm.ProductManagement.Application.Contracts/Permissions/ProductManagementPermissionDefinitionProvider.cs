using NovinCm.ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NovinCm.ProductManagement.Permissions;

public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var productGroup = context.AddGroup(ProductManagementPermissions.GroupProductManagementName);

        var productPermission = productGroup.AddPermission(ProductManagementPermissions.Products.Default, L("Permission:ProductManagement"));

        productPermission.AddChild(ProductManagementPermissions.Products.Create, L("Permission:ProductManagement:Create"));
        productPermission.AddChild(ProductManagementPermissions.Products.Delete, L("Permission:ProductManagement:Delete"));
        productPermission.AddChild(ProductManagementPermissions.Products.Edit, L("Permission:ProductManagement:Edit"));

        var categoryPermission = productGroup.AddPermission(ProductManagementPermissions.Categories.Default, L("Permission:CategoryManagement"));

        categoryPermission.AddChild(ProductManagementPermissions.Categories.Create, L("Permission:CategoryManagement:Create"));
        categoryPermission.AddChild(ProductManagementPermissions.Categories.Delete, L("Permission:CategoryManagement:Delete"));
        categoryPermission.AddChild(ProductManagementPermissions.Categories.Edit, L("Permission:CategoryManagement:Edit"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagementResource>(name);
    }
}
