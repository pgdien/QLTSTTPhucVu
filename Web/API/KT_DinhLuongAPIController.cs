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
    public class KT_DinhLuongAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/KT_DinhLuongAPI
        public IQueryable<KT_DinhLuong> GetKT_DinhLuong()
        {
            return db.KT_DinhLuong;
        }

        // GET: api/KT_DinhLuongAPI/5
        [ResponseType(typeof(KT_DinhLuong))]
        public IHttpActionResult GetKT_DinhLuong(int id)
        {
            KT_DinhLuong kT_DinhLuong = db.KT_DinhLuong.Find(id);
            if (kT_DinhLuong == null)
            {
                return NotFound();
            }

            return Ok(kT_DinhLuong);
        }

        // GET: api/KT_DinhLuongAPI?att=...&&value=...
        [ResponseType(typeof(KT_DinhLuong))]
        public IQueryable<KT_DinhLuong> GetKT_DinhLuong(string att, string value)
        {
            var model = db.KT_DinhLuong;

            if (att == "idThucDon")
            {
                int idThucDon = Int32.Parse(value);
                var thucdons = db.KT_DinhLuong.Where(p => p.idThucDon == idThucDon);
                return thucdons;
            }

            return model;
        }

        // PUT: api/KT_DinhLuongAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKT_DinhLuong(int id, KT_DinhLuong kT_DinhLuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kT_DinhLuong.id)
            {
                return BadRequest();
            }

            db.Entry(kT_DinhLuong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KT_DinhLuongExists(id))
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

        // POST: api/KT_DinhLuongAPI
        [ResponseType(typeof(KT_DinhLuong))]
        public IHttpActionResult PostKT_DinhLuong(KT_DinhLuong kT_DinhLuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KT_DinhLuong.Add(kT_DinhLuong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kT_DinhLuong.id }, kT_DinhLuong);
        }

        // DELETE: api/KT_DinhLuongAPI/5
        [ResponseType(typeof(KT_DinhLuong))]
        public IHttpActionResult DeleteKT_DinhLuong(int id)
        {
            KT_DinhLuong kT_DinhLuong = db.KT_DinhLuong.Find(id);
            if (kT_DinhLuong == null)
            {
                return NotFound();
            }

            db.KT_DinhLuong.Remove(kT_DinhLuong);
            db.SaveChanges();

            return Ok(kT_DinhLuong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KT_DinhLuongExists(int id)
        {
            return db.KT_DinhLuong.Count(e => e.id == id) > 0;
        }
    }
}