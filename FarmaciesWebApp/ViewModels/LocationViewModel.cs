using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciesWebApp.ViewModels
{
    public class LocationViewModel
    {
        public IEnumerable<Location> Locations { get; set; }

    }
}