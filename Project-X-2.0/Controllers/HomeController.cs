using Project_X_2._0.Entities;
using Project_X_2._0.Persistance;
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
        private readonly ITripRepository _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork, ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult Index()
        {
            var trips = _tripRepository.GetAll();
            return View((from t in trips
                        orderby t.Date ascending
                        select t));
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

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}