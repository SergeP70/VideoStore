using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;


namespace VideoStore.Controllers
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
        public ActionResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int? Id)
        {
            //Movie movie = GetMovies().FirstOrDefault(m => m.Id == Id);
            Movie movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return View(movie);
            }
        }


        //private IEnumerable<Movie> GetMovies()
        //{
        //    //return new List<Movie>();
        //    return new List<Movie>
        //    {
        //        new Movie {Id = 1, Name= "Heat"},
        //        new Movie {Id = 2, Name= "First Blood"},
        //        new Movie {Id = 3, Name= "Parasite"},
        //        new Movie {Id = 4, Name= "The Invisible Man"},
        //        new Movie {Id = 5, Name= "Gladiator"},
        //    };
        //}

    }
}