using KraftHeinz.Features.Repositories.Interfaces;
using KraftHeinz.Extensions;
using KraftHeinz.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KraftHeinz.Features.Models.Navigation;
using Sitecore.Data.Items;
using Sitecore;

namespace KraftHeinz.Features.Repositories
{
    public class NavigationRepository : INavigationRepository
    {
        
        public Item ContextItem { get; }
        public Item NavigationRoot { get; }

        public NavigationRepository(Item contextItem)
        {
            this.ContextItem = contextItem;
            this.NavigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (this.NavigationRoot == null)
            {
                throw new InvalidOperationException($"Cannot determine navigation root from '{this.ContextItem.Paths.FullPath}'");
            }
        }

        #region Public Methods

        public Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(NavigationTemplates.NavigationRoot.ID) ??
                   Sitecore.Context.Site.GetContextItem(NavigationTemplates.NavigationRoot.ID);
        }

        public NavigationItems GetPrimaryMenu()
        {
            var navItems = this.GetChildNavigationItems(this.NavigationRoot, 0, 1);

            this.AddRootToPrimaryMenu(navItems);
            return navItems;
        }

        public NavigationItems GetSecondaryMenuItem()
        {
            var rightItems = this.GetRightNavigationItems(this.NavigationRoot, 0, 1);
            return rightItems;
        }

        public NavigationItems GetLinkMenuItems(Item menuRoot)
        {
            if (menuRoot == null)
            {
                throw new ArgumentNullException(nameof(menuRoot));
            }
            return this.GetChildNavigationItems(menuRoot, 0, 0);
        }

        #endregion

        #region Private Methods

        private void AddRootToPrimaryMenu(NavigationItems navItems)
        {
            if (!this.IncludeInNavigation(this.NavigationRoot))
            {
                return;
            }

            var navigationItem = this.CreateNavigationItem(this.NavigationRoot, 0, 0);
            //Root navigation item is only active when we are actually on the root item
            navigationItem.IsActive = this.ContextItem.ID == this.NavigationRoot.ID;
            navItems?.Items?.Insert(0, navigationItem);
        }

        private NavigationItems GetChildNavigationItems(Item parentItem, int level, int maxLevel)
        {
            if (level > maxLevel || !parentItem.HasChildren)
            {
                return null;
            }
            var childItems = parentItem.Children
                .Where(item => this.IncludeInNavigation(item))
                .Select(i => this.CreateNavigationItem(i, level, maxLevel));

            return new NavigationItems
            {
                Items = childItems.ToList()
            };
        }

        private NavigationItems GetRightNavigationItems(Item parentItem, int level, int maxLevel)
        {
            if (level > maxLevel || !parentItem.HasChildren)
            {
                return null;
            }
            var childItems = parentItem.Children
                .Where(item => this.IncludeInNavigation(item) && this.IsSecundaryNavigation(item))
                .Select(i => this.CreateNavigationItem(i, level, maxLevel));

            return new NavigationItems
            {
                Items = childItems.ToList()
            };
        }

        private bool IncludeInNavigation(Item item, bool forceShowInMenu = false)
        {
            return item.HasContextLanguage() && item.IsDerived(NavigationTemplates.Navigable.ID) && (forceShowInMenu || MainUtil.GetBool(item[NavigationTemplates.Navigable.Fields.ShowInNavigation], false));
        }

        private bool IsSecundaryNavigation(Item item)
        {
            return item.HasContextLanguage() 
                && item.IsDerived(NavigationTemplates.Navigable.ID)
                && MainUtil.GetBool(item[NavigationTemplates.Navigable.Fields.IsSecundary], false);
        }

        private NavigationItem CreateNavigationItem(Item item, int level, int maxLevel = -1)
        {
            return new NavigationItem
            {
                Item = item,
                Url = (item.IsDerived(NavigationTemplates.LinkMenuItem.ID) ? item.LinkFieldUrl(NavigationTemplates.LinkMenuItem.Fields.Link) : item.Url()),
                Target = (item.IsDerived(NavigationTemplates.LinkMenuItem.ID) ? item.LinkFieldTarget(NavigationTemplates.LinkMenuItem.Fields.Link) : ""),
                IsActive = this.IsItemActive(item),
                IsSecundary = IsSecundaryNavigation(item),
                Children = this.GetChildNavigationItems(item, level + 1, maxLevel)
            };
        }

        private bool IsItemActive(Item item)
        {
            return this.ContextItem.ID == item.ID || this.ContextItem.Axes.GetAncestors().Any(a => a.ID == item.ID);
        }

        #endregion
    }
}