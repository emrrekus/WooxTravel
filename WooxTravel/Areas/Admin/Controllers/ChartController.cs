using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var destinations = context.Destinations
           .Select(d => new
           {
               Title = d.Title,
               Capacity = d.Capacity
           })
           .ToList();

            ViewBag.DestinationTitles = destinations.Select(d => d.Title).ToList();
            ViewBag.DestinationCapacities = destinations.Select(d => d.Capacity).ToList();

            return View();
        }
    }
}