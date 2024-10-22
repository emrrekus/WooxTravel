using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Inbox()
        {
            return View();
        }
    }
}