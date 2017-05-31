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
    public class KT_XuatHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/KT_XuatHangAPI
        public IQueryable<KT_XuatHang> GetKT_XuatHang()
        {
            return db.KT_XuatHang;
        }

        // GET: api/KT_XuatHangAPI/5
        [ResponseType(typeof(KT_XuatHang))]
        public IHttpActionResult GetKT_XuatHang(int id)
        {
            KT_XuatHang kT_XuatHang = db.KT_XuatHang.Find(id);
            if (kT_XuatHang == null)
            {
                return NotFound();
            }

            return Ok(kT_XuatHang);
        }

        // GET By Day
        [ResponseType(typeof(KT_XuatHang))]
        public IQueryable<KT_XuatHang> GetKT_XuatHang(string tuNgayDay, string tuNgayMonth, string tuNgayYear, string denNgayDay, string denNgayMonth, string denNgayYear)
        {
            DateTime tuNgay = new DateTime(int.Parse(tuNgayYear), int.Parse(tuNgayMonth), int.Parse(tuNgayDay), 0, 0, 0);
            DateTime denNgay = new DateTime(int.Parse(denNgayYear), int.Parse(denNgayMonth), int.Parse(denNgayDay), 0, 0, 0);

            var model = db.KT_XuatHang.Where(p => EntityFunctions.TruncateTime(p.thoigian.Value) >= tuNgay.Date && EntityFunctions.TruncateTime(p.thoigian.Value) <= denNgay.Date);

            return model;
        }

        // PUT: api/KT_XuatHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKT_XuatHang(int id, KT_XuatHang kT_XuatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kT_XuatHang.id)
            {
                return BadRequest();
            }

            db.Entry(kT_XuatHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KT_XuatHangExists(id))
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

        // POST: api/KT_XuatHangAPI
        [ResponseType(typeof(KT_XuatHang))]
        public IHttpActionResult PostKT_XuatHang(KT_XuatHang kT_XuatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KT_XuatHang.Add(kT_XuatHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kT_XuatHang.id }, kT_XuatHang);
        }

        // DELETE: api/KT_XuatHangAPI/5
        [ResponseType(typeof(KT_XuatHang))]
        public IHttpActionResult DeleteKT_XuatHang(int id)
        {
            KT_XuatHang kT_XuatHang = db.KT_XuatHang.Find(id);
            if (kT_XuatHang == null)
            {
                return NotFound();
            }

            db.KT_XuatHang.Remove(kT_XuatHang);
            db.SaveChanges();

            return Ok(kT_XuatHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KT_XuatHangExists(int id)
        {
            return db.KT_XuatHang.Count(e => e.id == id) > 0;
        }
    }
}