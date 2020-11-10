using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmaciesWebApp.ViewModels
{
    public class FarmacyFormViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PostalCode { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        [Required]
        [Display(Name ="Location")]
        public int LocationId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}