using FarmaciesWebApp.Models;
using FarmaciesWebApp.Repositories;
using FarmaciesWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciesWebApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public LocationController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: Location
        public ActionResult Index()
        {
            var locations = _unitOfWork.Locations.GetAllLocations();
            var viewModel = new LocationViewModel
            {
                Locations = locations
            };
            return View(viewModel);
        }
    }
}