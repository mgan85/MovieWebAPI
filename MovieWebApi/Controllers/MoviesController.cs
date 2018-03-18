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

        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovies(string title, int? releaseYear, string genre)
        {
            if (string.IsNullOrWhiteSpace(title) && releaseYear == null && string.IsNullOrWhiteSpace(genre))
                return BadRequest();

            IQueryable<Movie> movies = null;

            if (!string.IsNullOrWhiteSpace(title))
                movies = db.Movies.Where(x => x.Title.Contains(title));

            if (releaseYear != null)
                movies = movies != null ? movies.Where(x => x.ReleaseYear == releaseYear) : db.Movies.Where(x => x.ReleaseYear == releaseYear);

            if (!string.IsNullOrWhiteSpace(genre))
                movies = movies != null ? movies.Where(x => x.Genre == genre) : db.Movies.Where(x => x.Genre == genre);

            if (movies == null || movies.FirstOrDefault() == null)
                return NotFound();

            return Ok(movies);
        }

        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> Top5Movies()
        {
            var top5Movies = db.Rates.GroupBy(x => x.MovieId)
                                     .Select(y => new { Id = y.Key, Rating = y.Average(z => z.Rating) })
                                     .Join(db.Movies, r => r.Id, m => m.Id, (r, m) => new {
                                         m.Id,
                                         m.Title,
                                         m.ReleaseYear,
                                         m.Genre,
                                         m.RunningTime,
                                         r.Rating
                                     })
                                     .OrderByDescending(y => y.Rating).Take(5);

            if (top5Movies.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(top5Movies);
        }

        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> Top5UserMovies(int? id)
        {
            if (id == null)
                return BadRequest();

            var top5UserMovies = db.Rates.Where(v => v.UserId == id)
                                     .GroupBy(x => x.MovieId)
                                     .Select(y => new { Id = y.Key, Rating = y.Average(z => z.Rating) })
                                     .Join(db.Movies, r => r.Id, m => m.Id, (r, m) => new
                                     {
                                         m.Id,
                                         m.Title,
                                         m.ReleaseYear,
                                         m.RunningTime,
                                         r.Rating
                                     })
                                     .OrderByDescending(y => y.Rating).Take(5);

            if (top5UserMovies.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(top5UserMovies);

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