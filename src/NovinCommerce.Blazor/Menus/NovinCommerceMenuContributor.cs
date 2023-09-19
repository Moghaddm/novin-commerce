using System.Threading.Tasks;
using NovinCommerce.Localization;
using NovinCommerce.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace NovinCommerce.Blazor.Menus;

public class NovinCommerceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
            await ConfigureMainMenuAsync(context);
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<NovinCommerceResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                NovinCommerceMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        else
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        /* Add Product Management Item */
        context.Menu.Items.Insert(
           1,
           new ApplicationMenuItem(
               NovinCommerceMenus.Product,
               l["Menu:Product"],
               "/products",
               icon: "fas fa-shopping-cart"
           )
       );

        return Task.CompletedTask;
    }
}
