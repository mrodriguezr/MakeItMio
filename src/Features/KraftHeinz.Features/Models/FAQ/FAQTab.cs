using Sitecore.Data.Items;
using System.Collections.Generic;

namespace KraftHeinz.Features.Models.FAQ
{
    public class FAQTab
    {
        public Item Item { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item> FAQItems { get; set; }
    }
}