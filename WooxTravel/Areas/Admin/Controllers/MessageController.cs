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
            var a = Session["x"];
            var email = context.Admins.Where(x => x.Username == a).Select(x => x.Email).FirstOrDefault();
            var values = context.Messages.Where(x=>x.ReceiverMail==email).ToList();

            return View(values);
        }


        public ActionResult SendBox()
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.Username == a).Select(x => x.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderMail == email).ToList();

            return View(values);
        }

        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.Username == a).Select(x => x.Email).FirstOrDefault();
            message.SenderMail = email;
            message.SendDate = DateTime.Now;
            message.IsRead =false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("SendBox", "Message", new {area="Admin"});
        }
    }

   
}