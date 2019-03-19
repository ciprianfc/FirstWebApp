using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Customer(Customer customer)
        {         
            return View(customer);
        }

        public ActionResult AllCustomers()
        {
            var viewModel = new AllCustomersViewModel();
    
            return View(viewModel);
        }
    }
}