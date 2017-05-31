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
    public class DM_DonViThoiGianAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_DonViThoiGianAPI
        public IQueryable<DM_DonViThoiGian> GetDM_DonViThoiGian()
        {
            return db.DM_DonViThoiGian;
        }

        // GET: api/DM_DonViThoiGianAPI/5
        [ResponseType(typeof(DM_DonViThoiGian))]
        public IHttpActionResult GetDM_DonViThoiGian(int id)
        {
            DM_DonViThoiGian dM_DonViThoiGian = db.DM_DonViThoiGian.Find(id);
            if (dM_DonViThoiGian == null)
            {
                return NotFound();
            }

            return Ok(dM_DonViThoiGian);
        }

        // PUT: api/DM_DonViThoiGianAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_DonViThoiGian(int id, DM_DonViThoiGian dM_DonViThoiGian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_DonViThoiGian.id)
            {
                return BadRequest();
            }

            db.Entry(dM_DonViThoiGian).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_DonViThoiGianExists(id))
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

        // POST: api/DM_DonViThoiGianAPI
        [ResponseType(typeof(DM_DonViThoiGian))]
        public IHttpActionResult PostDM_DonViThoiGian(DM_DonViThoiGian dM_DonViThoiGian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_DonViThoiGian.Add(dM_DonViThoiGian);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_DonViThoiGian.id }, dM_DonViThoiGian);
        }

        // DELETE: api/DM_DonViThoiGianAPI/5
        [ResponseType(typeof(DM_DonViThoiGian))]
        public IHttpActionResult DeleteDM_DonViThoiGian(int id)
        {
            DM_DonViThoiGian dM_DonViThoiGian = db.DM_DonViThoiGian.Find(id);
            if (dM_DonViThoiGian == null)
            {
                return NotFound();
            }

            db.DM_DonViThoiGian.Remove(dM_DonViThoiGian);
            db.SaveChanges();

            return Ok(dM_DonViThoiGian);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_DonViThoiGianExists(int id)
        {
            return db.DM_DonViThoiGian.Count(e => e.id == id) > 0;
        }
    }
}