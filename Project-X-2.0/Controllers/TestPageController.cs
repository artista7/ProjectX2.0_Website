using PagedList;
using Project_X_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_X_2._0.Controllers
{
    [AllowAnonymous]
    public class TestPageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestPage
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var places = db.Places
                .Where(p => searchTerm == null || p.Name.Contains(searchTerm))
                .OrderBy(p => p.Name)
                .ToPagedList(page, 5);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_PlacesList", places);
            }

            return View(places);
        }

        // GET: AutoComplete
        public ActionResult AutoComplete(string term)
        {
            var places = db.Places
                .Where(p => term == null || p.Name.Contains(term))
                .OrderBy(p => p.Name)
                .Select(r => new { label = r.Name });

            return Json(places, JsonRequestBehavior.AllowGet);
        }
    }
}