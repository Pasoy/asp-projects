using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        /**
         * Possible Action Results:
         *
         * ViewResult = View()
         * PartialViewResult = PartialView()
         * ContentResult = Content()
         * RedirectResult = Redirect()
         * RedirectToRouteResult = RedirectToAction()
         * JsonResult = Json()
         * FileResult = File()
         * HttpNotFoundResult = HttpNotFound()
         * EmptyResult
         */

        /**
         * Parameter Sources:
         *
         * In the URL: /movies/edit/1
         * In the query string: /movies/edit?id=1
         * In the form data: id=1
         */
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}