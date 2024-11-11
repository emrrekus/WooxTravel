using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class CrediCartController : Controller
    {
        // GET: Admin/CrediCart
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}