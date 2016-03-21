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
    public class CarouselSlides
    {
        public IEnumerable<Item> Items { get; set; }

        public static IEnumerable<Item> GetCarouselSlides(Item item)
        {
            
            var items = MediaRepository.GetChildren(item);
            return items;
        }
    }
}