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
    public class ORDER_ChiTietNhanVienHoaDonBanHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/ORDER_ChiTietNhanVienHoaDonBanHangAPI
        public IQueryable<ORDER_ChiTietNhanVienHoaDonBanHang> GetORDER_ChiTietNhanVienHoaDonBanHang()
        {
            return db.ORDER_ChiTietNhanVienHoaDonBanHang;
        }

        // GET: api/ORDER_ChiTietNhanVienHoaDonBanHangAPI/5
        [ResponseType(typeof(ORDER_ChiTietNhanVienHoaDonBanHang))]
        public IHttpActionResult GetORDER_ChiTietNhanVienHoaDonBanHang(int id)
        {
            ORDER_ChiTietNhanVienHoaDonBanHang oRDER_ChiTietNhanVienHoaDonBanHang = db.ORDER_ChiTietNhanVienHoaDonBanHang.Find(id);
            if (oRDER_ChiTietNhanVienHoaDonBanHang == null)
            {
                return NotFound();
            }

            return Ok(oRDER_ChiTietNhanVienHoaDonBanHang);
        }

        // PUT: api/ORDER_ChiTietNhanVienHoaDonBanHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDER_ChiTietNhanVienHoaDonBanHang(int id, ORDER_ChiTietNhanVienHoaDonBanHang oRDER_ChiTietNhanVienHoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDER_ChiTietNhanVienHoaDonBanHang.id)
            {
                return BadRequest();
            }

            db.Entry(oRDER_ChiTietNhanVienHoaDonBanHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDER_ChiTietNhanVienHoaDonBanHangExists(id))
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

        // POST: api/ORDER_ChiTietNhanVienHoaDonBanHangAPI
        [ResponseType(typeof(ORDER_ChiTietNhanVienHoaDonBanHang))]
        public IHttpActionResult PostORDER_ChiTietNhanVienHoaDonBanHang(ORDER_ChiTietNhanVienHoaDonBanHang oRDER_ChiTietNhanVienHoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDER_ChiTietNhanVienHoaDonBanHang.Add(oRDER_ChiTietNhanVienHoaDonBanHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = oRDER_ChiTietNhanVienHoaDonBanHang.id }, oRDER_ChiTietNhanVienHoaDonBanHang);
        }

        // DELETE: api/ORDER_ChiTietNhanVienHoaDonBanHangAPI/5
        [ResponseType(typeof(ORDER_ChiTietNhanVienHoaDonBanHang))]
        public IHttpActionResult DeleteORDER_ChiTietNhanVienHoaDonBanHang(int id)
        {
            ORDER_ChiTietNhanVienHoaDonBanHang oRDER_ChiTietNhanVienHoaDonBanHang = db.ORDER_ChiTietNhanVienHoaDonBanHang.Find(id);
            if (oRDER_ChiTietNhanVienHoaDonBanHang == null)
            {
                return NotFound();
            }

            db.ORDER_ChiTietNhanVienHoaDonBanHang.Remove(oRDER_ChiTietNhanVienHoaDonBanHang);
            db.SaveChanges();

            return Ok(oRDER_ChiTietNhanVienHoaDonBanHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDER_ChiTietNhanVienHoaDonBanHangExists(int id)
        {
            return db.ORDER_ChiTietNhanVienHoaDonBanHang.Count(e => e.id == id) > 0;
        }
    }
}