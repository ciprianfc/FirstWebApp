using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
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

        // GET: Movies
        public ActionResult Random()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }



        public ActionResult Index(/*int? pageIndex, string sortBy*/)
        {
            #region not use this anymore
            //if (!pageIndex.HasValue) pageIndex = 1;
            //if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            //return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            #endregion

            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);


        }

        public ActionResult Movie(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.UtcNow;
                _context.Movies.Add(movie);
            }
            else
            {
                var dbMovie = _context.Movies.Single(c => c.Id == movie.Id);

                dbMovie.Name = movie.Name;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.DateAdded = movie.DateAdded;
                dbMovie.GenreId = movie.GenreId;
                dbMovie.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
            //return View();
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(c => c.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}