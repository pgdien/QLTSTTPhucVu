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
    public class DM_LyDoXuatAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_LyDoXuatAPI
        public IQueryable<DM_LyDoXuat> GetDM_LyDoXuat()
        {
            return db.DM_LyDoXuat;
        }

        // GET: api/DM_LyDoXuatAPI/5
        [ResponseType(typeof(DM_LyDoXuat))]
        public IHttpActionResult GetDM_LyDoXuat(int id)
        {
            DM_LyDoXuat dM_LyDoXuat = db.DM_LyDoXuat.Find(id);
            if (dM_LyDoXuat == null)
            {
                return NotFound();
            }

            return Ok(dM_LyDoXuat);
        }

        // PUT: api/DM_LyDoXuatAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_LyDoXuat(int id, DM_LyDoXuat dM_LyDoXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_LyDoXuat.id)
            {
                return BadRequest();
            }

            db.Entry(dM_LyDoXuat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_LyDoXuatExists(id))
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

        // POST: api/DM_LyDoXuatAPI
        [ResponseType(typeof(DM_LyDoXuat))]
        public IHttpActionResult PostDM_LyDoXuat(DM_LyDoXuat dM_LyDoXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_LyDoXuat.Add(dM_LyDoXuat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_LyDoXuat.id }, dM_LyDoXuat);
        }

        // DELETE: api/DM_LyDoXuatAPI/5
        [ResponseType(typeof(DM_LyDoXuat))]
        public IHttpActionResult DeleteDM_LyDoXuat(int id)
        {
            DM_LyDoXuat dM_LyDoXuat = db.DM_LyDoXuat.Find(id);
            if (dM_LyDoXuat == null)
            {
                return NotFound();
            }

            db.DM_LyDoXuat.Remove(dM_LyDoXuat);
            db.SaveChanges();

            return Ok(dM_LyDoXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_LyDoXuatExists(int id)
        {
            return db.DM_LyDoXuat.Count(e => e.id == id) > 0;
        }
    }
}