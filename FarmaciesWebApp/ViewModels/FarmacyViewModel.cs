using FarmaciesWebApp.Models;
using System;
using System.Collections.Generic;
using PagedList;
using System.Linq;
using System.Web;

namespace FarmaciesWebApp.ViewModels
{
    public class FarmacyViewModel
    {
        public PagedList.IPagedList<Farmacy> Farmacies { get; set; }
        public string SearchString { get; set; }
    }
}