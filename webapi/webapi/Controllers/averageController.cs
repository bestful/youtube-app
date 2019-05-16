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