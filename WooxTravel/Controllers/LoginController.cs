using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(Admin admin)
        {
            if (ModelState.IsValid) // Modelin geçerliliğini kontrol et
            {
                var values = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

                if (values != null)
                {
                    FormsAuthentication.SetAuthCookie(values.Username, false);
                    Session["x"] = values.Username;
                    return RedirectToAction("Index", "Profile", new { area = "Admin" });
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid credentials!";
                    return View();
                }
            }

            return View(admin);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index", "Login");

        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }

    }
}