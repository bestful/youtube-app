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
    public class videosController : ApiController
    {
        private Entities2 db = new Entities2();

        // GET: api/videos
        public IQueryable<video> Getvideo()
        {
            return db.video;
        }

        // GET: api/videos/5
        [ResponseType(typeof(video))]
        public IHttpActionResult Getvideo(int id)
        {
            video video = db.video.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        // PUT: api/videos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvideo(int id, video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.id)
            {
                return BadRequest();
            }

            db.Entry(video).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!videoExists(id))
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

        // POST: api/videos
        [ResponseType(typeof(video))]
        public IHttpActionResult Postvideo(video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.video.Add(video);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = video.id }, video);
        }

        // DELETE: api/videos/5
        [ResponseType(typeof(video))]
        public IHttpActionResult Deletevideo(int id)
        {
            video video = db.video.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            db.video.Remove(video);
            db.SaveChanges();

            return Ok(video);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool videoExists(int id)
        {
            return db.video.Count(e => e.id == id) > 0;
        }
    }
}