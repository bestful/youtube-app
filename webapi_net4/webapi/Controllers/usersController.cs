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

        // POST: api/users
        [ResponseType(typeof(void))]
        public IHttpActionResult Postuser(user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(user).State = EntityState.Modified;
            try
            {
                db.user.Add(user);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                
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