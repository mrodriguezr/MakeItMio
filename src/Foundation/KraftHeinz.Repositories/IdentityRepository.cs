using System;
using Sitecore;
using Sitecore.Data.Items;
using KraftHeinz.Extensions;
using KraftHeinz.Templates;

namespace KraftHeinz.Repositories
{
    public class IdentityRepository
    {
        public static Item Get(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(IdentityTemplates.Identity.ID) ?? Context.Site.GetContextItem(IdentityTemplates.Identity.ID);
        }
    }
}
