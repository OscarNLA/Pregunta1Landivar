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
using Pr1LandivarAPI.Models;

namespace Pr1LandivarAPI.Controllers
{
    public class LandivarsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Landivars
        [Authorize]
        public IQueryable<Landivar> GetLandivars()
        {
            return db.Landivars;
        }

        // GET: api/Landivars/5
        [Authorize]
        [ResponseType(typeof(Landivar))]
        public IHttpActionResult GetLandivar(int id)
        {
            Landivar landivar = db.Landivars.Find(id);
            if (landivar == null)
            {
                return NotFound();
            }

            return Ok(landivar);
        }

        // PUT: api/Landivars/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLandivar(int id, Landivar landivar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != landivar.LandivarID)
            {
                return BadRequest();
            }

            db.Entry(landivar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandivarExists(id))
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

        // POST: api/Landivars
        [Authorize]
        [ResponseType(typeof(Landivar))]
        public IHttpActionResult PostLandivar(Landivar landivar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Landivars.Add(landivar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = landivar.LandivarID }, landivar);
        }

        // DELETE: api/Landivars/5
        [Authorize]
        [ResponseType(typeof(Landivar))]
        public IHttpActionResult DeleteLandivar(int id)
        {
            Landivar landivar = db.Landivars.Find(id);
            if (landivar == null)
            {
                return NotFound();
            }

            db.Landivars.Remove(landivar);
            db.SaveChanges();

            return Ok(landivar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LandivarExists(int id)
        {
            return db.Landivars.Count(e => e.LandivarID == id) > 0;
        }
    }
}