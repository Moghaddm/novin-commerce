using NovinCommerce.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NovinCommerce.Permissions.Product
{
    public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var productGroup = context.AddGroup(NovinCommercePermissions.GroupProductManagementName);

            var productPermission = productGroup.AddPermission(NovinCommercePermissions.Products.Default, L("Permission:ProductManagement"));

            productPermission.AddChild(NovinCommercePermissions.Products.Create, L("Permission:ProductManagement:Create"));
            productPermission.AddChild(NovinCommercePermissions.Products.Delete, L("Permission:ProductManagement:Delete"));
            productPermission.AddChild(NovinCommercePermissions.Products.Edit, L("Permission:ProductManagement:Edit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<NovinCommerceResource>(name);
        }
    }
}
