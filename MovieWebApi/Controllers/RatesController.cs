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
using Newtonsoft.Json.Linq;

namespace MovieWebApi.Controllers
{
    public class RatesController : ApiController
    {
        private MovieWebApiContext db = new MovieWebApiContext();

        public IQueryable<Rate> GetRates()
        {
            return db.Rates;
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> AddRate(Rate rate)
        {
            if (rate.MovieId == null || rate.UserId == null)
                return NotFound();

            if (rate.Rating < 1 || rate.Rating > 5)
                return BadRequest();

            var rating = db.Rates.Where(x => x.MovieId == rate.MovieId && x.UserId == rate.UserId).FirstOrDefault();
                    
            if (rating == null)
                db.Rates.Add(new Rate { MovieId = rate.MovieId, UserId = rate.UserId, Rating = rate.Rating });
            else
                rating.Rating = rate.Rating;

            Movie movie = await db.Movies.FindAsync(rate.MovieId);
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