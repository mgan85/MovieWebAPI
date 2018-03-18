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
    public class RatesController : ApiController
    {
        private MovieWebApiContext db = new MovieWebApiContext();

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> AddRate(int? movieId, int? userId, int? rate)
        {
            if (movieId == null || userId == null)
                return NotFound();

            if (rate < 1 || rate > 5)
                return BadRequest();

            var rating = db.Rates.Where(x => x.MovieId == movieId && x.UserId == userId).FirstOrDefault();

            if (rating == null)
                db.Rates.Add(new Rate { MovieId = movieId, UserId = userId, Rating = rate });
            else
                rating.Rating = rate;

            Movie movie = await db.Movies.FindAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            movie.AverageRating = averageRating(movie.Id);
            await db.SaveChangesAsync();

            return Ok();
        }

        private double? averageRating(int movieId)
        {
            return db.Rates.Where(x => x.MovieId == movieId).Average(y => y.Rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RateExists(int id)
        {
            return db.Rates.Count(e => e.MovieId == id) > 0;
        }
    }
}