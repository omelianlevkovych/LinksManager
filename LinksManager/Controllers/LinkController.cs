using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinksManager.Repositories;
using LinksManager.Repositories.Repositories;
using LinksManager.Entities;
using LinksManager.Models;

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

            //read why do we actually use jsonrequstbehavior!
            //http://stackoverflow.com/questions/26390806/when-to-use-jsonresult-over-actionresult
            //its cos of json and action result difference
            return Json(links, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLink(int id)
        {
            var link = _linkRepository.Get(id);

            return Json(link, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddLink(LinkModel linkModel)
        {
            LinkEntity linkEntity = (LinkEntity)linkModel;
            LinkEntity addedLinkEntity = _linkRepository.Add(linkEntity);

            return Json(addedLinkEntity);
        }

        [HttpPost]
        public JsonResult UpdateLink(LinkModel linkModel)
        {
            LinkEntity linkEntity = (LinkEntity)linkModel;
            LinkEntity updateddLinkEntity = _linkRepository.Update(linkEntity);

            return Json(updateddLinkEntity);
        }

        [HttpPost]
        public ActionResult RemoveLink(LinkModel linkModel)
        {
            _linkRepository.Remove(linkModel.Id);

            return new EmptyResult();
        }
    }
}