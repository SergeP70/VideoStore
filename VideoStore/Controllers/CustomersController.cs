using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }


        public ActionResult Details(int? Id)
        {
            Customer customer = GetCustomers().FirstOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return View(customer);
            }
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name="John Smith"},
                new Customer {Id = 2, Name="Mary Williams"},
                new Customer {Id = 3, Name="Vicky Engels"},
                new Customer {Id = 4, Name="Idris Elba"},
                new Customer {Id = 5, Name="John Singleton"},
            };

        }

    }
}