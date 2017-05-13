using Project_X_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_X_2._0.Controllers
{ 
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var trips = db.Trips.ToList();
            return View((from t in trips
                        orderby t.Date ascending
                        select t).Take(5));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*protected override void Dispose(bool disposing)
        {
            if (db!=null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}