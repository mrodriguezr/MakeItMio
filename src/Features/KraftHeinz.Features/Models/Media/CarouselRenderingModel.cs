using System;
using Sitecore.Mvc.Presentation;
using KraftHeinz.Repositories;
using KraftHeinz.Extensions;
using KraftHeinz.Templates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;

namespace KraftHeinz.Features.Models.Media
{
    public static class CarouselRenderingModel
    {
        public static IEnumerable<Item> GetCarouselSlides(RenderingModel rendering)
        {
            var items = RenderingContext.Current.ContextItem.Children.Where(i => i.IsDerived(MediaTemplates.HasMedia.ID));

            return items;
        }
    }
}