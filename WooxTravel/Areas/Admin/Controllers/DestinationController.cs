using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class DestinationController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult DestinationList()
        {
            return View(context.Destinations.ToList());
        }


        public ActionResult CreateDestination()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDestination(Destination item)
        {
            item.CreatedTime = DateTime.Now;
            context.Destinations.Add(item);
            context.SaveChanges();

            return RedirectToAction("DestinationList", "Destination", "Admin");
        }



        public ActionResult DeleteDestination(int id)
        {
            context.Destinations.Remove(context.Destinations.Find(id));
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateDestination(int id)
        {
            return View(context.Destinations.Find(id));
        }


        [HttpPost]

        public ActionResult UpdateDestination(Destination item)
        {
            var value = context.Destinations.Find(item.DestinationId);
            value.Description = item.Description;
            value.City = item.City;
            value.DayNight = item.DayNight;
            value.Country = item.Country;
            value.ImageUrl = item.ImageUrl;
            value.Price = item.Price;
            value.Title = item.Title;
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
    }
}