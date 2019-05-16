using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using webapi.Models;

namespace webapi.Controllers
{
    public class averageController : ApiController
    {
        private Entities2 db = new Entities2();

        // GET: api/average
        public IQueryable<avg> Getavg()
        {
            return db.avg;
        }

        // GET: api/average/5
        [ResponseType(typeof(avg))]
        public IHttpActionResult Getavg(int id)
        {
            avg avg = db.avg.Find(id);
            if (avg == null)
            {
                return NotFound();
            }

            return Ok(avg);
        }

        // PUT: api/average/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putavg(int id, avg avg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avg.id)
            {
                return BadRequest();
            }

            db.Entry(avg).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!avgExists(id))
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

        // POST: api/average
        [ResponseType(typeof(avg))]
        public IHttpActionResult Postavg(avg avg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.avg.Add(avg);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (avgExists(avg.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = avg.id }, avg);
        }

        // DELETE: api/average/5
        [ResponseType(typeof(avg))]
        public IHttpActionResult Deleteavg(int id)
        {
            avg avg = db.avg.Find(id);
            if (avg == null)
            {
                return NotFound();
            }

            db.avg.Remove(avg);
            db.SaveChanges();

            return Ok(avg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool avgExists(int id)
        {
            return db.avg.Count(e => e.id == id) > 0;
        }
    }
}