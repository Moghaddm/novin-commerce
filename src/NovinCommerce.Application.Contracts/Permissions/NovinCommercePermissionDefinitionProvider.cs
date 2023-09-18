using NovinCommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NovinCommerce.Permissions;

public class NovinCommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NovinCommercePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NovinCommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NovinCommerceResource>(name);
    }
}
