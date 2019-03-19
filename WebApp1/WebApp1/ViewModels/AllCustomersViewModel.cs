using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class AllCustomersViewModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>
        {
            new Customer{Name = "Customer 1", Id = 1},
            new Customer{Name = "Customer 2", Id = 2},
            new Customer{Name = "Customer 3", Id = 3},
        };
    }
}