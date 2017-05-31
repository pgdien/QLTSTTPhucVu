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
    public class DM_KhachHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_KhachHangAPI
        public IQueryable<DM_KhachHang> GetDM_KhachHang()
        {
            return db.DM_KhachHang;
        }

        // GET: api/DM_KhachHangAPI/5
        [ResponseType(typeof(DM_KhachHang))]
        public IHttpActionResult GetDM_KhachHang(int id)
        {
            DM_KhachHang dM_KhachHang = db.DM_KhachHang.Find(id);
            if (dM_KhachHang == null)
            {
                return NotFound();
            }

            return Ok(dM_KhachHang);
        }

        // PUT: api/DM_KhachHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_KhachHang(int id, DM_KhachHang dM_KhachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_KhachHang.id)
            {
                return BadRequest();
            }

            db.Entry(dM_KhachHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_KhachHangExists(id))
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

        // POST: api/DM_KhachHangAPI
        [ResponseType(typeof(DM_KhachHang))]
        public IHttpActionResult PostDM_KhachHang(DM_KhachHang dM_KhachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_KhachHang.Add(dM_KhachHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_KhachHang.id }, dM_KhachHang);
        }

        // DELETE: api/DM_KhachHangAPI/5
        [ResponseType(typeof(DM_KhachHang))]
        public IHttpActionResult DeleteDM_KhachHang(int id)
        {
            DM_KhachHang dM_KhachHang = db.DM_KhachHang.Find(id);
            if (dM_KhachHang == null)
            {
                return NotFound();
            }

            db.DM_KhachHang.Remove(dM_KhachHang);
            db.SaveChanges();

            return Ok(dM_KhachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_KhachHangExists(int id)
        {
            return db.DM_KhachHang.Count(e => e.id == id) > 0;
        }
    }
}