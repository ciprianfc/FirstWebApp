using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}