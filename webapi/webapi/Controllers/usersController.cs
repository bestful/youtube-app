using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Description;
using webapi.Models;

namespace webapi.Controllers
{
    public class usersController : ApiController
    {
        private Entities2 db = new Entities2();

        // GET: api/users
        public IQueryable<user> Getuser()
        {
            return db.user;
        }

        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Loginuser(user user)
        {
            user correctUser;
            try {
                correctUser = db.user.Find(new { username = user.username });
                return Ok(new { loggedIn = true});
            }
            catch (NullReferenceException)
            {
                return Ok(new { loggedIn = false });
            }
            

        }

        // PUT: api/users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser(int id, user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(int id)
        {
            return db.user.Count(e => e.id == id) > 0;
        }
    }
}