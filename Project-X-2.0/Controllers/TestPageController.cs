﻿using PagedList;
using Project_X_2._0.Entities;
using Project_X_2._0.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Project_X_2._0.Controllers
{
    [AllowAnonymous]
    public class TestPageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlaceRepository _placeRepository;

        public TestPageController(IUnitOfWork unitOfWork, IPlaceRepository placeRepository)
        {
            _unitOfWork = unitOfWork;
            _placeRepository = placeRepository;
        }

        //output stored in memoryfor 20 mins
        //Dont expect the places to be added in db too frequently
        //VaryByHeader added to prevent ajax caxhed file to load while doing http request
        [OutputCache(CacheProfile="Short", VaryByHeader="X-Requested-With, Accept-Language", Location=OutputCacheLocation.Server)] 
        // GET: TestPage
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var places = _placeRepository.GetAll()
                .Where(p => searchTerm == null || p.Name.Contains(searchTerm))
                .OrderBy(p => p.Name)
                .ToPagedList(page, 5);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_PlacesList", places);
            }

            return View(places);
        }

        [OutputCache(CacheProfile="Medium")]  //output stored in memoryfor 20 mins - dont expect the places to be added in db too frequently
        // GET: AutoComplete
        public ActionResult AutoComplete(string term)
        {
            var places = _placeRepository.GetAll()
                .Where(p => term == null || p.Name.Contains(term))
                .OrderBy(p => p.Name)
                .Select(r => new { label = r.Name });

            return Json(places, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}