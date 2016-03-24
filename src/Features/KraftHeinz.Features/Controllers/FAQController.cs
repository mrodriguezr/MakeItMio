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
    public class FAQController : Controller
    {
        private readonly IFAQRepository _faqRepository;

        public FAQController() : this (new FAQRepository(RenderingContext.Current.Rendering.Item))
        {
        }

        public FAQController(IFAQRepository repository)
        {
            _faqRepository = repository;
        }

        public ActionResult FAQTabs()
        {
            var faq = _faqRepository.GetFAQ();
            return View("FAQTabs");
        }
    }
}