using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KraftHeinz.Features.Models.Navigation
{
    public class NavigationItems : RenderingModel
    {
        public IList<NavigationItem> Items { get; set; }
    }
}