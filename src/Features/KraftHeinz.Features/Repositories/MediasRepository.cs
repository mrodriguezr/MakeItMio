using KraftHeinz.Extensions;
using KraftHeinz.Features.Models.Media;
using KraftHeinz.Features.Repositories.Interfaces;
using KraftHeinz.Templates;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;

namespace KraftHeinz.Features.Repositories
{
    public class MediasRepository : IMediaRepository
    {
        public CarouselSlides Get(Item contextItem)
        {
           var items = contextItem.Children.Where(i => i.IsDerived(new ID("{D1C46BBC-E086-4B4B-8066-CD41B16B1BF0}")));
            return new CarouselSlides
            {
                Items = items
            };
        }
    }
}