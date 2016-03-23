using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KraftHeinz.Features.Models.Navigation
{
    public class NavigationItem
    {
        public Item Item { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public bool IsSecundary { get; set; }
        public int Level { get; set; }
        public NavigationItems Children { get; set; }
        public string Target { get; set; }
    }
}