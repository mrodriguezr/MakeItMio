using KraftHeinz.Features.Models.Media;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraftHeinz.Features.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        CarouselSlides Get(Item contextItem);
    }
}
