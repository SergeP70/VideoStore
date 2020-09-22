using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;

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
            // var movies = _context.Movies.Include(m => m.Genre).ToList(); VIA API
            return View();
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

        public ActionResult New()
        {
            //Movie movie = new Movie();
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres,
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            /*
             * 1. Add Data Annotations on the entity
             * 2. Use modelstate.valid to change flow, if not valid: return the same view
             * 3. Add validation messages to our form
             */

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                    
                };

                return View("MovieForm", viewModel);
            }
            

            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
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