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
    public class DM_MatHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_MatHangAPI
        public IQueryable<DM_MatHang> GetDM_MatHang()
        {
            return db.DM_MatHang;
        }

        // GET: api/DM_MatHangAPI/5
        [ResponseType(typeof(DM_MatHang))]
        public IHttpActionResult GetDM_MatHang(int id)
        {
            DM_MatHang dM_MatHang = db.DM_MatHang.Find(id);
            if (dM_MatHang == null)
            {
                return NotFound();
            }

            return Ok(dM_MatHang);
        }

        // GET: api/DM_MatHangAPI?att=...&&value=...
        [ResponseType(typeof(DM_MatHang))]
        public IQueryable<DM_MatHang> GetDM_MatHang(string att, string value)
        {
            var model = db.DM_MatHang;

            if (att == "idNhomMatHang")
            {
                int idNhomMatHang = Int32.Parse(value);
                var mathangs = db.DM_MatHang.Where(p => p.idNhomMatHang == idNhomMatHang).OrderBy(p => p.ten);
                return mathangs;
            }

            return model;
        }

        // PUT: api/DM_MatHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_MatHang(int id, DM_MatHang dM_MatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_MatHang.id)
            {
                return BadRequest();
            }

            db.Entry(dM_MatHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_MatHangExists(id))
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

        // POST: api/DM_MatHangAPI
        [ResponseType(typeof(DM_MatHang))]
        public IHttpActionResult PostDM_MatHang(DM_MatHang dM_MatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_MatHang.Add(dM_MatHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_MatHang.id }, dM_MatHang);
        }

        // DELETE: api/DM_MatHangAPI/5
        [ResponseType(typeof(DM_MatHang))]
        public IHttpActionResult DeleteDM_MatHang(int id)
        {
            DM_MatHang dM_MatHang = db.DM_MatHang.Find(id);
            if (dM_MatHang == null)
            {
                return NotFound();
            }

            db.DM_MatHang.Remove(dM_MatHang);
            db.SaveChanges();

            return Ok(dM_MatHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_MatHangExists(int id)
        {
            return db.DM_MatHang.Count(e => e.id == id) > 0;
        }
    }
}