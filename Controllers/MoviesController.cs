﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using Vidly.Models;
using Vidly.ViewModels;
using WebGrease.Css.Extensions;

namespace Vidly.Controllers
{
    
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;
       
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
  

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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


        //movies
        [Authorize(Roles = RoleName.CanManageMovies)]
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
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MoviesIndex()
        {
            //MovieViewModel model = new MovieViewModel();
           
            //var movies = new List<Movie>
            //{
            //    new Movie { Id = 1, Name = "Gwiezdniejsze wojenky" },
            //    new Movie {Id = 2, Name = "Blade runnerek"}
            //};

            //model.Movies = movies;
           // var movies = _context.Movies.Include(m=>m.MovieGenre).ToList();
           if (User.IsInRole("CanManageMovies"))
            return View("List");
            return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            Movie mov = _context.Movies.Include(m=>m.MovieGenre).SingleOrDefault(m => m.Id == id);
            if (mov == null)
                return HttpNotFound();

            return View(mov);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie viewModel)
        {
            //if(viewModel.Movie.DateAdded == null)
            //    viewModel.Movie.DateAdded = DateTime.Now;
            //ModelState.Clear();
            //ValidateModel(viewModel);

            if (!ModelState.IsValid)
            {
                var localViewModel = new MovieViewModel(viewModel)
                {
                    //Movie = viewModel.Movie,
                    MovieGenres = _context.MovieGenres.ToList()
                };
                return View("MovieForm", localViewModel);
            }

            if (viewModel.Id == 0)
            {
               // viewModel.Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(viewModel);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m=>m.Id == viewModel.Id);
                movieInDb.Name = viewModel.Name;
                movieInDb.MovieGenreId = viewModel.MovieGenreId;
                movieInDb.NumberInStock = viewModel.NumberInStock;
                movieInDb.ReleaseDate = viewModel.ReleaseDate;
            }

            //try
            //{
                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    string wynik = "";
            //    e.EntityValidationErrors.First().ValidationErrors.ForEach(er =>
            //        {
            //           wynik += er.ErrorMessage + Environment.NewLine;
            //        });
            //    return Content(wynik);

            //}
            
            return RedirectToAction("MoviesIndex", "Movies");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m=>m.MovieGenre).Single(m => m.Id == id);

            MovieViewModel movieModel = new MovieViewModel(movie)
            {
                
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", movieModel);
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            var viewModel = new MovieViewModel()
            {
                //Movie = new Movie(),
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }


    }
}