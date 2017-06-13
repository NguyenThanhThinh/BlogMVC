using BlogMVC.Models;
using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("ListCategories");
        }
        public ActionResult ListCategories()
        {
            using (var database = new BlogDbContext())
            {
                var categories = database.Categories.
                    Include(n => n.Name).
                    OrderBy(n => n.Name).
                    ToList();
                return View(categories);
            }
        }
        public ActionResult ListArticles(int? categoryId, int? page)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var articles = database.Articles
                    .Where(a => a.CategoryId == categoryId)
                    .Include(a => a.Author)
                    .Include(a => a.Tags);

                int pageSize = 3;
                int pageNumber = (page ?? 1);

                return View(articles.OrderBy(a => a.Title).ToPagedList(pageNumber, pageSize));
            }
        }
    }
}