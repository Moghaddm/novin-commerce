using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace NovinCm.ProductManagement.Blazor.Menus;

public class ProductManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ProductManagementMenus.Prefix, displayName: "Product Management", "/ProductManagement", icon: "fas fa-shopping-cart"));

        return Task.CompletedTask;
    }
}
