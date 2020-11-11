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
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index(string query=null)
        {
            var farmacies = _unitOfWork.Farmacies.GetAllFarmacies();
            if (!string.IsNullOrWhiteSpace(query))
            {
                farmacies = farmacies
                    .Where(f => f.Name.Contains(query) ||
                    f.Location.Name.Contains(query));
            }
            var viewModel = new FarmacyViewModel
            {
                Farmacies = farmacies,
                SearchString = query
            };

            return View("Farmacies", viewModel);
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
    }
}