using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Cotur.Abp.BlobManagement.Web.Menus;

public class BlobManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(BlobManagementMenus.Prefix, displayName: "BlobManagement", "~/BlobManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
