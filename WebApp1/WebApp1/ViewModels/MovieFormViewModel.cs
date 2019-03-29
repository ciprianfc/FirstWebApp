using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}