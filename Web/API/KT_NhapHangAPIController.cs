using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web.Models;

namespace Web.API
{
    public class KT_NhapHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/KT_NhapHangAPI
        public IQueryable<KT_NhapHang> GetKT_NhapHang()
        {
            return db.KT_NhapHang;
        }

        // GET: api/KT_NhapHangAPI/5
        [ResponseType(typeof(KT_NhapHang))]
        public IHttpActionResult GetKT_NhapHang(int id)
        {
            KT_NhapHang kT_NhapHang = db.KT_NhapHang.Find(id);
            if (kT_NhapHang == null)
            {
                return NotFound();
            }

            return Ok(kT_NhapHang);
        }

        // GET By Day
        [ResponseType(typeof(KT_NhapHang))]
        public IQueryable<KT_NhapHang> GetKT_NhapHang(string tuNgayDay, string tuNgayMonth, string tuNgayYear, string denNgayDay, string denNgayMonth, string denNgayYear)
        {
            DateTime tuNgay = new DateTime(int.Parse(tuNgayYear), int.Parse(tuNgayMonth), int.Parse(tuNgayDay), 0 , 0, 0);
            DateTime denNgay = new DateTime(int.Parse(denNgayYear), int.Parse(denNgayMonth), int.Parse(denNgayDay), 0, 0, 0);

            var model = db.KT_NhapHang.Where(p => EntityFunctions.TruncateTime(p.thoigian.Value) >= tuNgay.Date  && EntityFunctions.TruncateTime(p.thoigian.Value) <= denNgay.Date);

            return model;
        }

        // PUT: api/KT_NhapHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKT_NhapHang(int id, KT_NhapHang kT_NhapHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kT_NhapHang.id)
            {
                return BadRequest();
            }

            db.Entry(kT_NhapHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KT_NhapHangExists(id))
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

        // POST: api/KT_NhapHangAPI
        [ResponseType(typeof(KT_NhapHang))]
        public IHttpActionResult PostKT_NhapHang(KT_NhapHang kT_NhapHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KT_NhapHang.Add(kT_NhapHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kT_NhapHang.id }, kT_NhapHang);
        }

        // DELETE: api/KT_NhapHangAPI/5
        [ResponseType(typeof(KT_NhapHang))]
        public IHttpActionResult DeleteKT_NhapHang(int id)
        {
            KT_NhapHang kT_NhapHang = db.KT_NhapHang.Find(id);
            if (kT_NhapHang == null)
            {
                return NotFound();
            }

            db.KT_NhapHang.Remove(kT_NhapHang);
            db.SaveChanges();

            return Ok(kT_NhapHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KT_NhapHangExists(int id)
        {
            return db.KT_NhapHang.Count(e => e.id == id) > 0;
        }
    }
}