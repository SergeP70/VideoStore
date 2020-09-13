using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Models;

namespace VideoStore.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        // GET /api/movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movie;
        }

        // POST /api/movies
        
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (movieInDB==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDB.Name = movie.Name;
            movieInDB.GenreId = movie.GenreId;
            movieInDB.ReleaseDate = movie.ReleaseDate;
            movieInDB.DateAdded = movie.DateAdded;
            movieInDB.Stock = movie.Stock;

            _context.SaveChanges();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

        }

    }
}
