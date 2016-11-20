using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinksManager.Repositories;
using LinksManager.Repositories.Repositories;
using Newtonsoft.Json;

namespace LinksManager.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkRepository _linkRepository;

        public LinkController()
        {
            _linkRepository = new LinkRepository();
        }

        // GET: Link
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLinks()
        {
            var links = _linkRepository.GetLinks();

            var temp = JsonConvert.SerializeObject(links);
            return Json(links, JsonRequestBehavior.AllowGet);


        }
    }
}