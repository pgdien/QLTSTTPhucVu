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
    public class DM_DonViTinhAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_DonViTinhAPI
        public IQueryable<DM_DonViTinh> GetDM_DonViTinh()
        {
            return db.DM_DonViTinh.OrderBy(p => p.ten);
        }

        // GET: api/DM_DonViTinhAPI/5
        [ResponseType(typeof(DM_DonViTinh))]
        public IHttpActionResult GetDM_DonViTinh(int id)
        {
            DM_DonViTinh dM_DonViTinh = db.DM_DonViTinh.Find(id);
            if (dM_DonViTinh == null)
            {
                return NotFound();
            }

            return Ok(dM_DonViTinh);
        }

        // PUT: api/DM_DonViTinhAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_DonViTinh(int id, DM_DonViTinh dM_DonViTinh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_DonViTinh.id)
            {
                return BadRequest();
            }

            db.Entry(dM_DonViTinh).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_DonViTinhExists(id))
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

        // POST: api/DM_DonViTinhAPI
        [ResponseType(typeof(DM_DonViTinh))]
        public IHttpActionResult PostDM_DonViTinh(DM_DonViTinh dM_DonViTinh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_DonViTinh.Add(dM_DonViTinh);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_DonViTinh.id }, dM_DonViTinh);
        }

        // DELETE: api/DM_DonViTinhAPI/5
        [ResponseType(typeof(DM_DonViTinh))]
        public IHttpActionResult DeleteDM_DonViTinh(int id)
        {
            DM_DonViTinh dM_DonViTinh = db.DM_DonViTinh.Find(id);
            if (dM_DonViTinh == null)
            {
                return NotFound();
            }

            db.DM_DonViTinh.Remove(dM_DonViTinh);
            db.SaveChanges();

            return Ok(dM_DonViTinh);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_DonViTinhExists(int id)
        {
            return db.DM_DonViTinh.Count(e => e.id == id) > 0;
        }
    }
}