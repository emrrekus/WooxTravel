﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;
using PagedList;
using PagedList.Mvc;

namespace WooxTravel.Controllers
{
    public class DefaultController : Controller
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
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialBanner()
        {
            var value = context.Destinations.Where(x => x.IsBanner == true).ToList();

            return PartialView(value);
        }
        public PartialViewResult PartialVisitCountry(int page = 1)
        {
            var values = context.Destinations.ToList().ToPagedList(page, 4);
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialPopup()
        {
            var value = context.Destinations.ToList();
            return PartialView(value);
        }



        public ActionResult DestinationDetails(int id)
        {

            var tours = context.Destinations.ToList();
            var value = context.Destinations.Find(id);

            ViewBag.tour = tours;

            return View(value);

        }


        [HttpGet]
        public ActionResult AddResarvation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResarvation(Reservation res)
        {
            try
            {
                res.CreatedTime = DateTime.Now;
                context.Reservations.Add(res);
                context.SaveChanges();
                return Json(new { success = true, message = "Rezervasyonunuz başarıyla oluşturuldu." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Rezervasyon oluşturulurken bir hata oluştu." });
            }

        }
    }
}