﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class LayoutAdminController : Controller
    {
        
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

            return PartialView();
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