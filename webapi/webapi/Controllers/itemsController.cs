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
    public class itemsController : ApiController
    {
        private Entities2 db = new Entities2();

        // GET: api/items/5
        [ResponseType(typeof(item))]
        public IHttpActionResult Getitem(int id)
        {
            item item = db.item.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // POST: api/items
        [ResponseType(typeof(item))]
        public IHttpActionResult Postitem(item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.item.Add(item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (itemExists(item.user_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.user_id }, item);
        }

        // DELETE: api/items/5
        [ResponseType(typeof(item))]
        public IHttpActionResult Deleteitem(int id)
        {
            item item = db.item.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.item.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemExists(int id)
        {
            return db.item.Count(e => e.user_id == id) > 0;
        }
    }
}