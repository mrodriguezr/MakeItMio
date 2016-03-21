using KraftHeinz.Extensions;
using KraftHeinz.Features.Repositories;
using KraftHeinz.Features.Repositories.Interfaces;
using KraftHeinz.Templates;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using System.Linq;
using System.Web.Mvc;

namespace KraftHeinz.Features.Controllers
{
    public class MediaFeatureController : SitecoreController
    {
        IMediaRepository repository;

        public MediaFeatureController() : this (new MediasRepository())
        {
        }

        public MediaFeatureController(IMediaRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Carousel()
        {
            var children = RenderingContext.Current.ContextItem.Children;
            foreach(Item slide in children)
            {
                CarouselSlide(slide);
            }

            return View(repository.Get(RenderingContext.Current.ContextItem));
        }

        public ActionResult CarouselSlide(Item model)
        {
            var rendering = new RenderingModel();
            rendering.Rendering = new Rendering { Item = model };

            return View("~/Views/Media/CarouselSlide.cshtml", rendering);
        }
    }
}