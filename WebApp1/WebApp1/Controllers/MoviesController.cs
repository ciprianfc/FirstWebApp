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
            var movies = _context.Movies.Include(c=>c.Genre).ToList();

            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult Movie(int id)
        {
            var movie = _context.Movies.Include(c=>c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}