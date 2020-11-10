using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciesWebApp.Repositories
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public FarmacyRepository Farmacies { get; private set; }
        public LocationRepository Locations { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Farmacies = new FarmacyRepository(context);
            Locations = new LocationRepository(context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}