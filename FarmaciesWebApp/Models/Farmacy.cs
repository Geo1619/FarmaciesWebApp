using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace FarmaciesWebApp.Models
{
    public class Farmacy
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:255,MinimumLength =2,ErrorMessage ="Please type a valid Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public Location Location { get; set; }
        [Required]
        public int LocationId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}