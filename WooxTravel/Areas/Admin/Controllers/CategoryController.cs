using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;


namespace WooxTravel.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult CategoryList()
        {
            return View(context.Categories.ToList());
        }
    }
}