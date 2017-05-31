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
    public class KT_ChiTietNhapHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/KT_ChiTietNhapHangAPI
        public IQueryable<KT_ChiTietNhapHang> GetKT_ChiTietNhapHang()
        {
            return db.KT_ChiTietNhapHang;
        }

        // GET: api/KT_ChiTietNhapHangAPI/5
        [ResponseType(typeof(KT_ChiTietNhapHang))]
        public IHttpActionResult GetKT_ChiTietNhapHang(int id)
        {
            KT_ChiTietNhapHang kT_ChiTietNhapHang = db.KT_ChiTietNhapHang.Find(id);
            if (kT_ChiTietNhapHang == null)
            {
                return NotFound();
            }

            return Ok(kT_ChiTietNhapHang);
        }

        // GET: api/KT_ChiTietNhapHangAPI?att=...&&value=...
        [ResponseType(typeof(KT_ChiTietNhapHang))]
        public IQueryable<KT_ChiTietNhapHang> GetKT_ChiTietNhapHang(string att, string value)
        {
            var model = db.KT_ChiTietNhapHang;

            if (att == "idNhapHang")
            {
                int idNhapHang = Int32.Parse(value);
                var chitiets = db.KT_ChiTietNhapHang.Where(p => p.idNhapHang == idNhapHang);
                return chitiets;
            }

            return model;
        }

        // PUT: api/KT_ChiTietNhapHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKT_ChiTietNhapHang(int id, KT_ChiTietNhapHang kT_ChiTietNhapHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kT_ChiTietNhapHang.id)
            {
                return BadRequest();
            }

            db.Entry(kT_ChiTietNhapHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KT_ChiTietNhapHangExists(id))
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

        // POST: api/KT_ChiTietNhapHangAPI
        [ResponseType(typeof(KT_ChiTietNhapHang))]
        public IHttpActionResult PostKT_ChiTietNhapHang(KT_ChiTietNhapHang kT_ChiTietNhapHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KT_ChiTietNhapHang.Add(kT_ChiTietNhapHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kT_ChiTietNhapHang.id }, kT_ChiTietNhapHang);
        }

        // DELETE: api/KT_ChiTietNhapHangAPI/5
        [ResponseType(typeof(KT_ChiTietNhapHang))]
        public IHttpActionResult DeleteKT_ChiTietNhapHang(int id)
        {
            KT_ChiTietNhapHang kT_ChiTietNhapHang = db.KT_ChiTietNhapHang.Find(id);
            if (kT_ChiTietNhapHang == null)
            {
                return NotFound();
            }

            db.KT_ChiTietNhapHang.Remove(kT_ChiTietNhapHang);
            db.SaveChanges();

            return Ok(kT_ChiTietNhapHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KT_ChiTietNhapHangExists(int id)
        {
            return db.KT_ChiTietNhapHang.Count(e => e.id == id) > 0;
        }
    }
}