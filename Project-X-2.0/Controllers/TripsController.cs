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
using System.IO;

namespace Project_X_2._0.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TripsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ITripRepository _tripRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITripPictureRepository _tripPictureRepository;

        public TripsController(IUnitOfWork unitOfWork, ITripRepository tripRepository, IPlaceRepository placeRepository, ITripPictureRepository tripPictureRepository)
        {
            _unitOfWork = unitOfWork;
            _tripRepository = tripRepository;
            _placeRepository = placeRepository;
            _tripPictureRepository = tripPictureRepository;
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
        
        // GET: Trips/AddImage
        public ActionResult AddImage()
        {
            //ViewBag.PlaceID = new SelectList(_placeRepository.GetAll(), "PlaceID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(TripPicture model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            /*ContentRepository service = new ContentRepository();
            int i = service.UploadImageInDataBase(file, model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }*/
            this.UploadImageInDataBase(file, model);
            return View(model);
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

        public void UploadImageInDataBase(HttpPostedFileBase file, TripPicture contentViewModel)
        {
            contentViewModel.Image = ConvertToBytes(file);
            var Content = new TripPicture
            {
                Title = contentViewModel.Title,
                Description = contentViewModel.Description,
                Contents = contentViewModel.Contents,
                Image = contentViewModel.Image
            };
            _tripPictureRepository.Add(Content);
            _unitOfWork.Commit();
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
