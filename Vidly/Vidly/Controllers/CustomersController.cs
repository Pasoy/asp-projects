using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // access db
        private ApplicationDbContext _context;

        public CustomersController()
        {
            // initialize db
            _context = new ApplicationDbContext();
        }

        // dbcontext is a disposable object and we need to properly dispose it
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            /*
             * initiate customers from context db.
             * with .ToList() the query will be executed immediately
             *
             * eager loading
             */
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}