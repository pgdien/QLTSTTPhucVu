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
    public class ORDER_HoaDonBanHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/ORDER_HoaDonBanHangAPI
        public IQueryable<ORDER_HoaDonBanHang> GetORDER_HoaDonBanHang()
        {
            return db.ORDER_HoaDonBanHang;
        }

        // GET: api/ORDER_HoaDonBanHangAPI/5
        [ResponseType(typeof(ORDER_HoaDonBanHang))]
        public IHttpActionResult GetORDER_HoaDonBanHang(int id)
        {
            ORDER_HoaDonBanHang oRDER_HoaDonBanHang = db.ORDER_HoaDonBanHang.Find(id);
            if (oRDER_HoaDonBanHang == null)
            {
                return NotFound();
            }

            return Ok(oRDER_HoaDonBanHang);
        }

        // GET: api/ORDER_HoaDonBanHangAPI?att=...&&value=...
        [ResponseType(typeof(ORDER_HoaDonBanHang))]
        public IQueryable<ORDER_HoaDonBanHang> GetORDER_HoaDonBanHang(string att, string value)
        {
            var model = db.ORDER_HoaDonBanHang;

            if (att == "idBan")
            {
                int idBan = Int32.Parse(value);
                var hoadonBanHangs = db.ORDER_HoaDonBanHang.Where(p => p.idBan == idBan && p.isThanhToan == false && p.isHuy == false);
                return hoadonBanHangs;
            }

            return model;
        }

        // GET By Day
        [ResponseType(typeof(ORDER_HoaDonBanHang))]
        public IQueryable<ORDER_HoaDonBanHang> GetORDER_HoaDonBanHang(string tuNgayDay, string tuNgayMonth, string tuNgayYear, string denNgayDay, string denNgayMonth, string denNgayYear)
        {
            DateTime tuNgay = new DateTime(int.Parse(tuNgayYear), int.Parse(tuNgayMonth), int.Parse(tuNgayDay), 0, 0, 0);
            DateTime denNgay = new DateTime(int.Parse(denNgayYear), int.Parse(denNgayMonth), int.Parse(denNgayDay), 0, 0, 0);

            var model = db.ORDER_HoaDonBanHang.Where(p => EntityFunctions.TruncateTime(p.thoigianVao.Value) >= tuNgay.Date && EntityFunctions.TruncateTime(p.thoigianVao.Value) <= denNgay.Date && p.isThanhToan == true && p.isHuy == false);

            return model;
        }

        // PUT: api/ORDER_HoaDonBanHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDER_HoaDonBanHang(int id, ORDER_HoaDonBanHang oRDER_HoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDER_HoaDonBanHang.id)
            {
                return BadRequest();
            }

            db.Entry(oRDER_HoaDonBanHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDER_HoaDonBanHangExists(id))
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

        // POST: api/ORDER_HoaDonBanHangAPI
        [ResponseType(typeof(ORDER_HoaDonBanHang))]
        public IHttpActionResult PostORDER_HoaDonBanHang(ORDER_HoaDonBanHang oRDER_HoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDER_HoaDonBanHang.Add(oRDER_HoaDonBanHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = oRDER_HoaDonBanHang.id }, oRDER_HoaDonBanHang);
        }

        // DELETE: api/ORDER_HoaDonBanHangAPI/5
        [ResponseType(typeof(ORDER_HoaDonBanHang))]
        public IHttpActionResult DeleteORDER_HoaDonBanHang(int id)
        {
            ORDER_HoaDonBanHang oRDER_HoaDonBanHang = db.ORDER_HoaDonBanHang.Find(id);
            if (oRDER_HoaDonBanHang == null)
            {
                return NotFound();
            }

            db.ORDER_HoaDonBanHang.Remove(oRDER_HoaDonBanHang);
            db.SaveChanges();

            return Ok(oRDER_HoaDonBanHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDER_HoaDonBanHangExists(int id)
        {
            return db.ORDER_HoaDonBanHang.Count(e => e.id == id) > 0;
        }
    }
}