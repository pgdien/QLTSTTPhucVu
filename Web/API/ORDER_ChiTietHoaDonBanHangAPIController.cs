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
    public class ORDER_ChiTietHoaDonBanHangAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/ORDER_ChiTietHoaDonBanHangAPI
        public IQueryable<ORDER_ChiTietHoaDonBanHang> GetORDER_ChiTietHoaDonBanHang()
        {
            return db.ORDER_ChiTietHoaDonBanHang;
        }

        // GET: api/ORDER_ChiTietHoaDonBanHangAPI/5
        [ResponseType(typeof(ORDER_ChiTietHoaDonBanHang))]
        public IHttpActionResult GetORDER_ChiTietHoaDonBanHang(int id)
        {
            ORDER_ChiTietHoaDonBanHang oRDER_ChiTietHoaDonBanHang = db.ORDER_ChiTietHoaDonBanHang.Find(id);
            if (oRDER_ChiTietHoaDonBanHang == null)
            {
                return NotFound();
            }

            return Ok(oRDER_ChiTietHoaDonBanHang);
        }

        // PUT: api/ORDER_ChiTietHoaDonBanHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDER_ChiTietHoaDonBanHang(int id, ORDER_ChiTietHoaDonBanHang oRDER_ChiTietHoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDER_ChiTietHoaDonBanHang.id)
            {
                return BadRequest();
            }

            db.Entry(oRDER_ChiTietHoaDonBanHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDER_ChiTietHoaDonBanHangExists(id))
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

        // POST: api/ORDER_ChiTietHoaDonBanHangAPI
        [ResponseType(typeof(ORDER_ChiTietHoaDonBanHang))]
        public IHttpActionResult PostORDER_ChiTietHoaDonBanHang(ORDER_ChiTietHoaDonBanHang oRDER_ChiTietHoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDER_ChiTietHoaDonBanHang.Add(oRDER_ChiTietHoaDonBanHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = oRDER_ChiTietHoaDonBanHang.id }, oRDER_ChiTietHoaDonBanHang);
        }

        // DELETE: api/ORDER_ChiTietHoaDonBanHangAPI/5
        [ResponseType(typeof(ORDER_ChiTietHoaDonBanHang))]
        public IHttpActionResult DeleteORDER_ChiTietHoaDonBanHang(int id)
        {
            ORDER_ChiTietHoaDonBanHang oRDER_ChiTietHoaDonBanHang = db.ORDER_ChiTietHoaDonBanHang.Find(id);
            if (oRDER_ChiTietHoaDonBanHang == null)
            {
                return NotFound();
            }

            db.ORDER_ChiTietHoaDonBanHang.Remove(oRDER_ChiTietHoaDonBanHang);
            db.SaveChanges();

            return Ok(oRDER_ChiTietHoaDonBanHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDER_ChiTietHoaDonBanHangExists(int id)
        {
            return db.ORDER_ChiTietHoaDonBanHang.Count(e => e.id == id) > 0;
        }
    }
}