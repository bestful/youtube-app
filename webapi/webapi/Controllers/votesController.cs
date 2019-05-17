﻿using System;
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
    public class votesController : ApiController
    {
        private Entities2 db = new Entities2();

        // PUT: api/votes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvote(int id, vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vote.video_id)
            {
                return BadRequest();
            }

            db.Entry(vote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!voteExists(id))
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

        // DELETE: api/votes/5
        [ResponseType(typeof(vote))]
        public IHttpActionResult Deletevote(int id)
        {
            vote vote = db.vote.Find(id);
            if (vote == null)
            {
                return NotFound();
            }

            db.vote.Remove(vote);
            db.SaveChanges();

            return Ok(vote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool voteExists(int id)
        {
            return db.vote.Count(e => e.video_id == id) > 0;
        }
    }
}