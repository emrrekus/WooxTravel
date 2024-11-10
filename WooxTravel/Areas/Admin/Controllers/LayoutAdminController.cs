using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class LayoutAdminController : Controller
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
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            var username = Session["x"];
            var value = context.Admins.Where(x => x.Username == username).FirstOrDefault();


            return PartialView(value);
        }

        public PartialViewResult PartialMessageNavbar()
        {
            var username = Session["x"];

            var email = context.Admins.Where(x => x.Username == username).Select(x => x.Email).FirstOrDefault();

            var lastFourMessages = context.Messages.Where(x => x.ReceiverMail == email)
     .OrderByDescending(m => m.SendDate)
     .Take(4)
     .ToList();

            return PartialView(lastFourMessages);
        }

        public PartialViewResult PartialDestinationNavbar()
        {
            var values = context.Destinations.OrderByDescending(d => d.DestinationId).Take(4).ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {

            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}