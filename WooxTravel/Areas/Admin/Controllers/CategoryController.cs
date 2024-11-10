using PagedList;
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
    public class CategoryController : Controller
    {
        TravelContext context = new TravelContext();

        [Authorize]
        public ActionResult CategoryList(int page = 1)
        {
            var values = context.Categories
                .Where(c => c.CategoryStatus == true).ToList().ToPagedList(page, 6);
            return View(values);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            category.CategoryStatus = false;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }


        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            value.CategoryStatus = false;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
    }
}
