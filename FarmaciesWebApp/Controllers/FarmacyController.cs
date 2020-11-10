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

namespace FarmaciesWebApp.Controllers
{
    public class FarmacyController : Controller
    {
        private UnitOfWork _unitOfWork;
        public FarmacyController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Farmacy
        public ActionResult Index()
        {
            var farmacies = _unitOfWork.Farmacies.GetAllFarmacies();
            return View(farmacies);
        }

    }
}
