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
    public class DM_NhanVienPhucVuAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_NhanVienPhucVuAPI
        public IQueryable<DM_NhanVienPhucVu> GetDM_NhanVienPhucVu()
        {
            return db.DM_NhanVienPhucVu;
        }

        // GET: api/DM_NhanVienPhucVuAPI/5
        [ResponseType(typeof(DM_NhanVienPhucVu))]
        public IHttpActionResult GetDM_NhanVienPhucVu(int id)
        {
            DM_NhanVienPhucVu dM_NhanVienPhucVu = db.DM_NhanVienPhucVu.Find(id);
            if (dM_NhanVienPhucVu == null)
            {
                return NotFound();
            }

            return Ok(dM_NhanVienPhucVu);
        }

        // PUT: api/DM_NhanVienPhucVuAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_NhanVienPhucVu(int id, DM_NhanVienPhucVu dM_NhanVienPhucVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_NhanVienPhucVu.id)
            {
                return BadRequest();
            }

            db.Entry(dM_NhanVienPhucVu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_NhanVienPhucVuExists(id))
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

        // POST: api/DM_NhanVienPhucVuAPI
        [ResponseType(typeof(DM_NhanVienPhucVu))]
        public IHttpActionResult PostDM_NhanVienPhucVu(DM_NhanVienPhucVu dM_NhanVienPhucVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_NhanVienPhucVu.Add(dM_NhanVienPhucVu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_NhanVienPhucVu.id }, dM_NhanVienPhucVu);
        }

        // DELETE: api/DM_NhanVienPhucVuAPI/5
        [ResponseType(typeof(DM_NhanVienPhucVu))]
        public IHttpActionResult DeleteDM_NhanVienPhucVu(int id)
        {
            DM_NhanVienPhucVu dM_NhanVienPhucVu = db.DM_NhanVienPhucVu.Find(id);
            if (dM_NhanVienPhucVu == null)
            {
                return NotFound();
            }

            db.DM_NhanVienPhucVu.Remove(dM_NhanVienPhucVu);
            db.SaveChanges();

            return Ok(dM_NhanVienPhucVu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_NhanVienPhucVuExists(int id)
        {
            return db.DM_NhanVienPhucVu.Count(e => e.id == id) > 0;
        }
    }
}