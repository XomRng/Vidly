using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController()
        {
         _context = new ApplicationDbContext();   
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //CustomerViewModel model = new CustomerViewModel
        //{
        //    Customers = new List<Customer>
        //    {
        //        new Customer { Id = 0, Name = "Stefan Batory" },
        //        new Customer {Id = 1, Name = "Krzysztof Knoblaucht" }
        //    }
        //};

        public ActionResult CustomersIndex()
        {

            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult GetCustomer(int id)
        {

            Customer cust = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }
    }
}