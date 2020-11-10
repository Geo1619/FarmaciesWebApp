using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciesWebApp.Repositories
{
    public class FarmacyRepository
    {
        private readonly ApplicationDbContext _context;
        public FarmacyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Farmacy> GetAllFarmacies()
        {
            return _context.Farmacies.ToList();
        }
        public IEnumerable<Farmacy> GetFarmaciesByLocation(int id)
        {
            return _context.Farmacies
                .Where(f => f.Location.Id == id).ToList();
        }
        public void Add(Farmacy farmacy)
        {
            _context.Farmacies.Add(farmacy);
        }
    }
    
}