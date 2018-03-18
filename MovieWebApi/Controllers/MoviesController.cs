using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MovieWebApi.Models;

namespace MovieWebApi.Controllers
{
    public class MoviesController : ApiController
    {
        private MovieWebApiContext db = new MovieWebApiContext();

        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        private double averageRating(int movieId)
        {
            db.Rates.Where(x => x.MovieId == movieId).Average(y => y.Rating);
            return 0;
        }

        private void Top5Movies()
        {
            db.Rates.GroupBy(x => x.MovieId).Select(y => new { MovieId = y.Key, Rating = y.Average(z => z.Rating) }).OrderByDescending(y => y.Rating).Take(5);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}