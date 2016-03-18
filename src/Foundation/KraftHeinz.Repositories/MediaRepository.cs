using KraftHeinz.Templates;
using Sitecore.Data.Items;
using KraftHeinz.Extensions;
using Sitecore;

namespace KraftHeinz.Repositories
{
    public class MediaRepository
    {
        public static Item Get(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(MediaTemplates.HasMedia.ID) ?? 
                Context.Site.GetContextItem(MediaTemplates.HasMedia.ID);
        }
    }
}
