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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            //return View(movie);
           // return HttpNotFound();
           //return new EmptyResult();
           // return RedirectToAction("Index", "Home", new {Page = 1, sortBy = "name"});
            var viewResult = new ViewResult();
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };



            ViewBag.kek = movie;
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult MoviesIndex()
        {
            MovieViewModel model = new MovieViewModel();
           
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Gwiezdniejsze wojenky" },
                new Movie {Id = 2, Name = "Blade runnerek"}
            };
            model.Movies = movies;

            return View(model);
        }


    }
}