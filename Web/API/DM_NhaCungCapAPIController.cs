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
    public class DM_NhaCungCapAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_NhaCungCapAPI
        public IQueryable<DM_NhaCungCap> GetDM_NhaCungCap()
        {
            return db.DM_NhaCungCap;
        }

        // GET: api/DM_NhaCungCapAPI/5
        [ResponseType(typeof(DM_NhaCungCap))]
        public IHttpActionResult GetDM_NhaCungCap(int id)
        {
            DM_NhaCungCap dM_NhaCungCap = db.DM_NhaCungCap.Find(id);
            if (dM_NhaCungCap == null)
            {
                return NotFound();
            }

            return Ok(dM_NhaCungCap);
        }

        // PUT: api/DM_NhaCungCapAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_NhaCungCap(int id, DM_NhaCungCap dM_NhaCungCap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_NhaCungCap.id)
            {
                return BadRequest();
            }

            db.Entry(dM_NhaCungCap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_NhaCungCapExists(id))
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

        // POST: api/DM_NhaCungCapAPI
        [ResponseType(typeof(DM_NhaCungCap))]
        public IHttpActionResult PostDM_NhaCungCap(DM_NhaCungCap dM_NhaCungCap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_NhaCungCap.Add(dM_NhaCungCap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_NhaCungCap.id }, dM_NhaCungCap);
        }

        // DELETE: api/DM_NhaCungCapAPI/5
        [ResponseType(typeof(DM_NhaCungCap))]
        public IHttpActionResult DeleteDM_NhaCungCap(int id)
        {
            DM_NhaCungCap dM_NhaCungCap = db.DM_NhaCungCap.Find(id);
            if (dM_NhaCungCap == null)
            {
                return NotFound();
            }

            db.DM_NhaCungCap.Remove(dM_NhaCungCap);
            db.SaveChanges();

            return Ok(dM_NhaCungCap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_NhaCungCapExists(int id)
        {
            return db.DM_NhaCungCap.Count(e => e.id == id) > 0;
        }
    }
}