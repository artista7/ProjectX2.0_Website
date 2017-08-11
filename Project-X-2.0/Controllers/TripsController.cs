using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_X_2._0.Entities;
using Project_X_2._0.CustomFilters;
using Project_X_2._0.Persistance;

namespace Project_X_2._0.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TripsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ITripRepository _tripRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TripsController(IUnitOfWork unitOfWork, ITripRepository tripRepository, IPlaceRepository placeRepository)
        {
            _unitOfWork = unitOfWork;
            _tripRepository = tripRepository;
            _placeRepository = placeRepository;
        }

        [AllowAnonymous]
        // GET: Trips
        public ActionResult Index()
        {
            var trips = _tripRepository.GetAll();//.Include(t => t.Place);
            return View(trips.ToList());
        }

        [AllowAnonymous]
        // GET: Trips/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = _tripRepository.GetById(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            ViewBag.PlaceID = new SelectList(_placeRepository.GetAll(), "PlaceID", "Name");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TripID,Date,CostPerHead,PlaceID")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _tripRepository.Add(trip);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceID = new SelectList(_placeRepository.GetAll(), "PlaceID", "Name", trip.PlaceID);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = _tripRepository.GetById(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceID = new SelectList(_placeRepository.GetAll(), "PlaceID", "Name", trip.PlaceID);
            return View(trip);
        }
        
        
        // GET: Trips/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = _tripRepository.GetById(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = _tripRepository.GetById(id);
            _tripRepository.Remove(trip);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
