using Project_X_2._0.Entities;
using Project_X_2._0.Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_X_2._0.Controllers
{
    public class TripPicturesController : Controller
    {
        //private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private IUnitOfWork _unitOfWork;
        private ITripPictureRepository _tripPicturesRepository;

        public TripPicturesController(IUnitOfWork unitOfWork, ITripPictureRepository tripPictureRepository)
        {
            _unitOfWork = unitOfWork;
            _tripPicturesRepository = tripPictureRepository;
           //_tripPicturesRepository = unitOfWork.TripPictureRepository;
        }

        /*public TripPicturesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tripPicturesRepository = unitOfWork.TripPictureRepository;
        }*/
        // GET: TripPictures
        public ActionResult Index()
        {
            return View();
        }

        // GET: TripPictures/Create
        public ActionResult Create()
        {
            TripPicture tripPicture = new TripPicture();
            return View(tripPicture);
        }

        // POST: TripPictures/Create
        [HttpPost]
        public ActionResult Create(TripPicture model, HttpPostedFileBase ImageData)
        {
            if (ImageData != null)
            {
                model.TripId = 1;
                model.Image = this.ConvertToBytes(ImageData);
            }
            _tripPicturesRepository.Add(model);
            _unitOfWork.Commit();
            //_db.TripPictures.Add(model);
            //_db.SaveChanges();
            return View(model);
        }

        /*public void UploadImageInDataBase(HttpPostedFileBase file, TripPicture contentViewModel)
        {
            contentViewModel.Image = ConvertToBytes(file);
            var Content = new TripPicture
            {
                Title = contentViewModel.Title,
                Description = contentViewModel.Description,
                Contents = contentViewModel.Contents,
                Image = contentViewModel.Image
            };
            //_tripPictureRepository.Add(Content);
            //_unitOfWork.Commit();
        }*/
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public ActionResult RetrieveImage(int id)
        {
            byte[][] pics = GetImageFromDataBase(id);
            byte[] cover = pics[0];
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        /*public ActionResult RetrieveImages(int id)
        {
            byte[][] pics = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }*/

        public byte[][] GetImageFromDataBase(int Id)
        {
            var q = _tripPicturesRepository.GetAll().ToList();
            //var q = from temp in _db.TripPictures where temp.TripId == Id select temp.Image;
            var count = q.Count();
            byte[][] pics = new byte[count][];
            for(int i = 0; i < count; i++)
            {
                pics[i] = q.ElementAt(i).Image;
            }
            return pics;
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
