using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _context.Farmacies
                .Include(f => f.Location).ToList();
        }
        public IEnumerable<Farmacy> GetFarmaciesByLocation(int id)
        {
            return _context.Farmacies
                .Where(f => f.Location.Id == id)
                .Include(f => f.Location).ToList();
        }
        public void Add(Farmacy farmacy)
        {
            _context.Farmacies.Add(farmacy);
        }
        public void Remove(Farmacy farmacy) 
        {
            _context.Farmacies.Remove(farmacy);
        }
    }
}