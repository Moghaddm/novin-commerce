using System;
using System.Collections.Generic;
using System.Text;
using NovinCommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NovinCommerce.Permissions.Company
{
    public class CompanyManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var categoryGroup = context.AddGroup(NovinCommercePermissions.GroupCompanyManagementName);

            var categoryPermission = categoryGroup.AddPermission(NovinCommercePermissions.Companies.Default, L("Permission:CompanyManagement"));

            categoryPermission.AddChild(NovinCommercePermissions.Companies.Create, L("Permission:CompanyManagement:Create"));
            categoryPermission.AddChild(NovinCommercePermissions.Companies.Delete, L("Permission:CompanyManagement:Delete"));
            categoryPermission.AddChild(NovinCommercePermissions.Companies.Edit, L("Permission:CompanyManagement:Edit"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<NovinCommerceResource>(name);
        }
    }
}
