using Sitecore.Data.Items;
using System.Collections.Generic;

namespace KraftHeinz.Features.Models.FAQ
{
    public class FAQ
    {
        public Item Item { get; set; }
        public IList<FAQTab> FAQTabs { get; set; }
    }
}