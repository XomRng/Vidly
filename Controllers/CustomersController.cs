using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        //CustomerViewModel model = new CustomerViewModel
        //{
        //    Customers = new List<Customer>
        //    {
        //        new Customer { Id = 0, Name = "Stefan Batory" },
        //        new Customer {Id = 1, Name = "Krzysztof Knoblaucht" }
        //    }
        //};

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomersIndex()
        {

            var model = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(model);
        }

        [Route("customers/details/{id}")]
        public ActionResult GetCustomer(int id)
        {
           
            Customer cust = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };




            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        //To SAVE jest połączone z nazwa w BeginForm na view
        public ActionResult Save(CustomerFormViewModel formViewModel) // to jest model binding, parametr musi byc takiego samego typu jak model na View ktory przesyla dane.
        { //http post jako parametr przesyla do metody to co zostanie wpisane w VIEW przez uzytkownika
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = formViewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            } 

            if (formViewModel.Customer.Id == 0)
                _context.Customers.Add(formViewModel.Customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == formViewModel.Customer.Id);

                //TryUpdateModel(customerInDb, "", new string[] {"Name", "Email"}); // to jest kijowe, trzeba manualnie
                customerInDb.Name = formViewModel.Customer.Name;
                customerInDb.Birthdate = formViewModel.Customer.Birthdate;
                customerInDb.MembershipTypeId = formViewModel.Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = formViewModel.Customer.IsSubscribedToNewsletter;

                //trzeba poczytac o automapper, podobno mapuje wg konwencji
                //Mapper.Map(customer, customerInDb);

            //musze też poczytać o DTO, klasa ktora przetrzymuje tylko te dane ktore chce przekazac dalej w celach bezpieczenstwa.

            }
           
            _context.SaveChanges();

            //zwraca sie przekierowanie do jakiejs innej akcji niz ta ponieważ ta tylko zapisuje dane.
            return RedirectToAction("CustomersIndex", "Customers"); 
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            //zwracamy inny view niż w nazwie metody tak wiec konwencja nie zadziała
            // dlatego w return view musimy sprecyzowac jaki view bedziemy zwracać
            return View("CustomerForm", viewModel);
        }
    }
}