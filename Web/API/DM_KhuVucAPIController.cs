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
using Web.Models;

namespace Web.API
{
    public class DM_KhuVucAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_KhuVucAPI
        public IQueryable<DM_KhuVuc> GetDM_KhuVuc()
        {
            return db.DM_KhuVuc;
        }

        // GET: api/DM_KhuVucAPI/5
        [ResponseType(typeof(DM_KhuVuc))]
        public IHttpActionResult GetDM_KhuVuc(int id)
        {
            DM_KhuVuc dM_KhuVuc = db.DM_KhuVuc.Find(id);
            if (dM_KhuVuc == null)
            {
                return NotFound();
            }

            return Ok(dM_KhuVuc);
        }

        // PUT: api/DM_KhuVucAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_KhuVuc(int id, DM_KhuVuc dM_KhuVuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_KhuVuc.id)
            {
                return BadRequest();
            }

            db.Entry(dM_KhuVuc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_KhuVucExists(id))
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

        // POST: api/DM_KhuVucAPI
        [ResponseType(typeof(DM_KhuVuc))]
        public IHttpActionResult PostDM_KhuVuc(DM_KhuVuc dM_KhuVuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_KhuVuc.Add(dM_KhuVuc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_KhuVuc.id }, dM_KhuVuc);
        }

        // DELETE: api/DM_KhuVucAPI/5
        [ResponseType(typeof(DM_KhuVuc))]
        public IHttpActionResult DeleteDM_KhuVuc(int id)
        {
            DM_KhuVuc dM_KhuVuc = db.DM_KhuVuc.Find(id);
            if (dM_KhuVuc == null)
            {
                return NotFound();
            }

            db.DM_KhuVuc.Remove(dM_KhuVuc);
            db.SaveChanges();

            return Ok(dM_KhuVuc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_KhuVucExists(int id)
        {
            return db.DM_KhuVuc.Count(e => e.id == id) > 0;
        }
    }
}