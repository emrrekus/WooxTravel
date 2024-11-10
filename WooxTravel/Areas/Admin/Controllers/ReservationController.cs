using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult ReservationList(int page = 1)
        {

            var value = context.Reservations.ToList().ToPagedList(page, 9);
            return View(value);
        }
    }
}