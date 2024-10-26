using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;
using PagedList;
using PagedList.Mvc;

namespace WooxTravel.Controllers
{
    public class DefaultController : Controller
    {

        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialBanner()
        {
            var value = context.Destinations.Where(x => x.IsBanner == true).ToList();

            return PartialView(value);
        }
        public PartialViewResult PartialVisitCountry(int page=1)
        {
            var values = context.Destinations.ToList().ToPagedList(page,4);
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialPopup()
        {
            return PartialView();
        }

        public ActionResult PopupDeneme()
        {
            return View();
        }



        public ActionResult DestinationDetails(int id)
        {

            var tours= context.Destinations.ToList();
            var value = context.Destinations.Find(id);

           ViewBag.tour = tours;

            return View(value);

        }
    }
}