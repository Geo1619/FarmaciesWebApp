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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var farmacy = _unitOfWork.Farmacies.GetFarmacy(id);
            if (farmacy is null)
                return HttpNotFound();

            _unitOfWork.Farmacies.Remove(farmacy);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(int id)
        {
            var farmacy = _unitOfWork.Farmacies.GetFarmacy(id);
            if (farmacy is null)
                return HttpNotFound();

            var viewModel = new FarmacyFormViewModel
            {
                Id = farmacy.Id,
                Name = farmacy.Name,
                Address = farmacy.Address,
                Email = farmacy.Email,
                LocationId = farmacy.LocationId,
                PhoneNumber = farmacy.PhoneNumber,
                PostalCode = farmacy.PostalCode,
                Locations = _unitOfWork.Locations.GetAllLocations()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FarmacyFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {

                viewModel.Locations = _unitOfWork.Locations.GetAllLocations();
                return View("Edit", viewModel);
            }
            var farmacy = _unitOfWork.Farmacies.GetFarmacy(viewModel.Id);
            farmacy.Modify(viewModel.Name,viewModel.Address,
                viewModel.PostalCode,viewModel.LocationId,
                viewModel.PhoneNumber,viewModel.Email);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
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
