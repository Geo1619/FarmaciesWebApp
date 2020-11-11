using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmaciesWebApp.Models;
using FarmaciesWebApp.Repositories;
using FarmaciesWebApp.ViewModels;

namespace FarmaciesWebApp.Controllers
{
    public class FarmacyController : Controller
    {
        private UnitOfWork _unitOfWork;
        public FarmacyController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public ActionResult Create()
        {
            var viewModel = new FarmacyFormViewModel
            {
                Locations = _unitOfWork.Locations.GetAllLocations()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FarmacyFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Locations = _unitOfWork.Locations.GetAllLocations();
                return View("Create", viewModel);
            }
            var farmacy = new Farmacy
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Email = viewModel.Email,
                LocationId = viewModel.LocationId,
                PhoneNumber = viewModel.PhoneNumber,
                PostalCode = viewModel.PostalCode
            };
            _unitOfWork.Farmacies.Add(farmacy);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public ActionResult Search(FarmacyViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchString });
        }

    }
}
