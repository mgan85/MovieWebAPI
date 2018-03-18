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

        // GET: api/Rates
        public IQueryable<Rate> GetRates()
        {
            return db.Rates;
        }

        // GET: api/Rates/5
        [ResponseType(typeof(Rate))]
        public async Task<IHttpActionResult> GetRate(int id)
        {
            Rate rate = await db.Rates.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }

            return Ok(rate);
        }

        // PUT: api/Rates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRate(int id, Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rate.MovieId)
            {
                return BadRequest();
            }

            db.Entry(rate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rates
        [ResponseType(typeof(Rate))]
        public async Task<IHttpActionResult> PostRate(Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rates.Add(rate);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RateExists(rate.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rate.MovieId }, rate);
        }

        // DELETE: api/Rates/5
        [ResponseType(typeof(Rate))]
        public async Task<IHttpActionResult> DeleteRate(int id)
        {
            Rate rate = await db.Rates.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }

            db.Rates.Remove(rate);
            await db.SaveChangesAsync();

            return Ok(rate);
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