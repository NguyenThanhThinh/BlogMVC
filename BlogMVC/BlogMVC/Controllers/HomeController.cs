using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
        public ActionResult ListCategories()
        {
            using (var database = new BlogDbContext())
            {
                var categories = database.Categories.
                    Include(n => n.Articles).
                    OrderBy(n => n.Name).
                    ToList();
                return View(categories);
            }
        }
        public ActionResult ListArticles(int? categoryId, int? page)
=======

        public ActionResult About()
>>>>>>> parent of f720c89... add categories controller
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}