using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{

    public class DashboardController : Controller
    {
        TravelContext context = new TravelContext();

        [Authorize]
        public ActionResult Index()
        {
            var adminCount = context.Admins.ToList().Count();
            ViewBag.AdminCount = adminCount;

            var categoryCount = context.Categories.ToList().Count();
            ViewBag.CategoryCount = categoryCount;

            var destinationCount = context.Destinations.ToList().Count();
            ViewBag.DestinationCount = destinationCount;

            var messageCount = context.Messages.ToList().Count();
            ViewBag.MessageCount = messageCount;

            var reservationCount = context.Reservations.ToList().Count();
            ViewBag.ReservationCount = reservationCount;
                   
          
            var subjectThanksMessageCount = context.Messages.Where(x => x.Subject == "Teşekkür").Count();
            ViewBag.SubjectThanksMessageCount = subjectThanksMessageCount;

            var subjectComplaintMessageCount = context.Messages.Where(x => x.Subject == "Şikayet").Count();
            ViewBag.SubjectComplaintMessageCount = subjectComplaintMessageCount;

            var people2ReservationCount = context.Reservations.Where(x => x.PersonCount == 2).Count();
            ViewBag.People2ReservationCount = people2ReservationCount;


            var viyanaTourCount= context.Reservations.Where(x=> x.Tour=="Viyana").Count();
            ViewBag.viyanaCount= viyanaTourCount;

            var kölnTourCount = context.Reservations.Where(x => x.Tour == "Köln").Count();
            ViewBag.kölnCount = kölnTourCount;


            var maxCapacity = context.Destinations
                             .OrderByDescending(d => d.Capacity).Select(d => d.City)
                             .FirstOrDefault();
            ViewBag.maxCapatiy = maxCapacity;


            var maxDay= context.Destinations.OrderByDescending(x=> x.DayNight).Select(x => x.City).FirstOrDefault();

            ViewBag.maxDay = maxDay;
            return View();
        }
    }
}