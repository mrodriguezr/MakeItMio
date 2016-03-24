using System;
using KraftHeinz.Features.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using KraftHeinz.Features.Models.FAQ;
using KraftHeinz.Extensions;
using KraftHeinz.Templates;

namespace KraftHeinz.Features.Repositories 
{
    public class FAQRepository : IFAQRepository
    {
        public Item ContextItem { get; }

        public FAQRepository(Item contextItem)
        {
            this.ContextItem = contextItem;
        }

        public FAQ GetFAQ()
        {
            var faq = GetChildFaq();

            return faq;
        }
        
        private FAQ GetChildFaq()
        {
            var childItems = ContextItem.Children
                .Where(item => item.IsDerived(FAQTemplates.FAQTab.ID))
                .Select(i => this.CreateTabItem(i));

            return new FAQ
            {
                Item = ContextItem,
                FAQTabs = childItems.ToList()
            };
        }

        private FAQTab CreateTabItem(Item item)
        {
            return new FAQTab
            {
                Item = item,
                FAQItems = item.Children.Where(i => i.IsDerived(FAQTemplates.FAQItem.ID))
            };
        }

    }
}