using System;
using Sitecore;
using Sitecore.Data;
using Sitecore.Sites;
using Sitecore.Data.Items;

namespace MakeItMio.Extensions
{
    public static class SiteExtensions
    {
        #region Public Methods

        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var startItem = site.GetStartItem();
            return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }

        public static Item GetStartItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(Context.Site.StartPath);
        }

        #endregion
    }
}
