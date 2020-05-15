using System.Collections.Generic;
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
             */
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}