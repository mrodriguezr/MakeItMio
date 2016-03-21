using KraftHeinz.Templates;
using Sitecore.Data.Items;
using KraftHeinz.Extensions;
using Sitecore;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;

namespace KraftHeinz.Repositories
{
    public class MediaRepository
    {
        public static Item Get(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(MediaTemplates.HasMedia.ID) ?? 
                Context.Site.GetContextItem(MediaTemplates.HasMedia.ID);
        }

        public static IEnumerable<Item> GetChildren(Item contextItem)
        {
            var test = Context.Site.GetContextItem(new ID("{D1C46BBC-E086-4B4B-8066-CD41B16B1BF0}"));
            var items = contextItem.Children.Where(i => i.IsDerived(new ID("{D1C46BBC-E086-4B4B-8066-CD41B16B1BF0}")));

            return items;
        }
    }
}
