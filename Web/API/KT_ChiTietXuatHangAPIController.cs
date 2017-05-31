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
    public class KT_ChiTietXuatHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/KT_ChiTietXuatHangAPI
        public IQueryable<KT_ChiTietXuatHang> GetKT_ChiTietXuatHang()
        {
            return db.KT_ChiTietXuatHang;
        }

        // GET: api/KT_ChiTietXuatHangAPI/5
        [ResponseType(typeof(KT_ChiTietXuatHang))]
        public IHttpActionResult GetKT_ChiTietXuatHang(int id)
        {
            KT_ChiTietXuatHang kT_ChiTietXuatHang = db.KT_ChiTietXuatHang.Find(id);
            if (kT_ChiTietXuatHang == null)
            {
                return NotFound();
            }

            return Ok(kT_ChiTietXuatHang);
        }

        // GET: api/KT_ChiTietXuatHangAPI?att=...&&value=...
        [ResponseType(typeof(KT_ChiTietXuatHang))]
        public IQueryable<KT_ChiTietXuatHang> GetKT_ChiTietXuatHang(string att, string value)
        {
            var model = db.KT_ChiTietXuatHang;

            if (att == "idXuatHang")
            {
                int idXuatHang = Int32.Parse(value);
                var chitiets = db.KT_ChiTietXuatHang.Where(p => p.idXuatHang == idXuatHang);
                return chitiets;
            }

            return model;
        }

        // PUT: api/KT_ChiTietXuatHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKT_ChiTietXuatHang(int id, KT_ChiTietXuatHang kT_ChiTietXuatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kT_ChiTietXuatHang.id)
            {
                return BadRequest();
            }

            db.Entry(kT_ChiTietXuatHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KT_ChiTietXuatHangExists(id))
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

        // POST: api/KT_ChiTietXuatHangAPI
        [ResponseType(typeof(KT_ChiTietXuatHang))]
        public IHttpActionResult PostKT_ChiTietXuatHang(KT_ChiTietXuatHang kT_ChiTietXuatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KT_ChiTietXuatHang.Add(kT_ChiTietXuatHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kT_ChiTietXuatHang.id }, kT_ChiTietXuatHang);
        }

        // DELETE: api/KT_ChiTietXuatHangAPI/5
        [ResponseType(typeof(KT_ChiTietXuatHang))]
        public IHttpActionResult DeleteKT_ChiTietXuatHang(int id)
        {
            KT_ChiTietXuatHang kT_ChiTietXuatHang = db.KT_ChiTietXuatHang.Find(id);
            if (kT_ChiTietXuatHang == null)
            {
                return NotFound();
            }

            db.KT_ChiTietXuatHang.Remove(kT_ChiTietXuatHang);
            db.SaveChanges();

            return Ok(kT_ChiTietXuatHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KT_ChiTietXuatHangExists(int id)
        {
            return db.KT_ChiTietXuatHang.Count(e => e.id == id) > 0;
        }
    }
}