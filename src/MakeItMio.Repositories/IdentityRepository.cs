using System;
using Sitecore;
using Sitecore.Data.Items;
using MakeItMio.Extensions;
using Template = MakeItMio.Templates.Templates;

namespace MakeItMio.Repositories
{
    public class IdentityRepository
    {
        public static Item Get(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Template.Identity.ID) ?? Context.Site.GetContextItem(Template.Identity.ID);
        }
    }
}
