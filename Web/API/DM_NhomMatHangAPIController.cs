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
    public class DM_NhomMatHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_NhomMatHangAPI
        public IQueryable<DM_NhomMatHang> GetDM_NhomMatHang()
        {
            return db.DM_NhomMatHang;
        }

        // GET: api/DM_NhomMatHangAPI/5
        [ResponseType(typeof(DM_NhomMatHang))]
        public IHttpActionResult GetDM_NhomMatHang(int id)
        {
            DM_NhomMatHang dM_NhomMatHang = db.DM_NhomMatHang.Find(id);
            if (dM_NhomMatHang == null)
            {
                return NotFound();
            }

            return Ok(dM_NhomMatHang);
        }

        // PUT: api/DM_NhomMatHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_NhomMatHang(int id, DM_NhomMatHang dM_NhomMatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_NhomMatHang.id)
            {
                return BadRequest();
            }

            db.Entry(dM_NhomMatHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_NhomMatHangExists(id))
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

        // POST: api/DM_NhomMatHangAPI
        [ResponseType(typeof(DM_NhomMatHang))]
        public IHttpActionResult PostDM_NhomMatHang(DM_NhomMatHang dM_NhomMatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_NhomMatHang.Add(dM_NhomMatHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_NhomMatHang.id }, dM_NhomMatHang);
        }

        // DELETE: api/DM_NhomMatHangAPI/5
        [ResponseType(typeof(DM_NhomMatHang))]
        public IHttpActionResult DeleteDM_NhomMatHang(int id)
        {
            DM_NhomMatHang dM_NhomMatHang = db.DM_NhomMatHang.Find(id);
            if (dM_NhomMatHang == null)
            {
                return NotFound();
            }

            db.DM_NhomMatHang.Remove(dM_NhomMatHang);
            db.SaveChanges();

            return Ok(dM_NhomMatHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_NhomMatHangExists(int id)
        {
            return db.DM_NhomMatHang.Count(e => e.id == id) > 0;
        }
    }
}