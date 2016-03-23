using KraftHeinz.Features.Models.Navigation;
using Sitecore.Data.Items;

namespace KraftHeinz.Features.Repositories.Interfaces
{
    public interface INavigationRepository
    {
        Item GetNavigationRoot(Item contextItem);
        NavigationItems GetPrimaryMenu();
        NavigationItems GetSecondaryMenuItem();
        NavigationItems GetLinkMenuItems(Item menuItem);
    }
}
