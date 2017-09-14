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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();//need to dispose this obj
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        public ViewResult Index()
        {
          //  var customers = GetCustomers();
          var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //defered execution here, won't query immediately
            //query is actually executed when iterating over var 
            //customers in View.
            //To execute immediately call ToList();
            Console.WriteLine(customers.ToString());
            return View(customers);
        }

        public ActionResult Details(int id)
        {
           // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c =>c.MembershipType).SingleOrDefault(c => c.Id == id);
            //query immediately executed here with SingleOrDefaultMethod
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            
            var membershipTypes = _context.MembershipTypes.ToList();
            //create viewmodel to pass multiple data to view
            var viewModel = new CustomerFormViewModel
            {

                Customer  = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        /*  private IEnumerable<Customer> GetCustomers()
          {
              return new List<Customer>
              {
                  new Customer { Id = 1, Name = "John Smith" },
                  new Customer { Id = 2, Name = "Mary Williams" }
              };
          }*/

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = formViewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            
            if(formViewModel.Customer.Id == 0)
            _context.Customers.Add(formViewModel.Customer); //saved in memory
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == formViewModel.Customer.Id);
                //                TryUpdateModel(customerInDb); or
                customerInDb.Name = formViewModel.Customer.Name;
                customerInDb.BirthDate = formViewModel.Customer.BirthDate;
                customerInDb.MembershipTypeId = formViewModel.Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = formViewModel.Customer.IsSubscribedToNewsLetter;
                //Mapper.Map(customer, customerInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            //override default convention of view

            return View("CustomerForm", viewModel);
        }

        private bool IsNegative(int input)
        {
            if (input < 0)
                return true;
            return false;
        }
    }
}