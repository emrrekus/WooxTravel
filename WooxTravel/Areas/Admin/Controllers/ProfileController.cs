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
    public class ProfileController : Controller
    {
      TravelContext context=new TravelContext();
        [Authorize]
        public ActionResult Index()
        {
            var a = Session["x"];
            var values = context.Admins.Where(x => x.Username == a).FirstOrDefault();
            return View(values);
        }
    }
}