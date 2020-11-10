using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciesWebApp.Repositories
{
    public class LocationRepository
    {
        private readonly ApplicationDbContext _context;
        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

    }
}