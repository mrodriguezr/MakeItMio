using KraftHeinz.Features.Repositories;
using KraftHeinz.Features.Repositories.Interfaces;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KraftHeinz.Features.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationRepository _navigationRepository;

        public NavigationController() : this (new NavigationRepository(RenderingContext.Current.Rendering.Item))
        {
        }

        public NavigationController(INavigationRepository repository)
        {
            _navigationRepository = repository;
        }

        public ActionResult PrimaryMenu()
        {
            var items = _navigationRepository.GetPrimaryMenu();
            return View("PrimaryMenu", items);
        }

        public ActionResult SecondaryMenu()
        {
            var items = _navigationRepository.GetSecondaryMenuItem();
            return View("SecundaryMenu", items);
        }

        public ActionResult NavigationLinks()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return null;
            }
            var item = RenderingContext.Current.Rendering.Item;
            var items = this._navigationRepository.GetLinkMenuItems(item);
            return this.View("NavigationLinks", items);
        }

    }
}