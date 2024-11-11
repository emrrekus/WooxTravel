using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;
using PagedList;
using PagedList.Mvc;

namespace WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Inbox(int page=1)
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.Username == a).Select(x => x.Email).FirstOrDefault();
            var values = context.Messages.Where(x=>x.ReceiverMail==email).ToList().ToPagedList(page,5);

            return View(values);
        }


        public ActionResult SendBox(int page=1)
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.Username == a).Select(x => x.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderMail == email).ToList().ToPagedList(page,5);

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