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
    public class DM_LyDoNhapAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_LyDoNhapAPI
        public IQueryable<DM_LyDoNhap> GetDM_LyDoNhap()
        {
            return db.DM_LyDoNhap;
        }

        // GET: api/DM_LyDoNhapAPI/5
        [ResponseType(typeof(DM_LyDoNhap))]
        public IHttpActionResult GetDM_LyDoNhap(int id)
        {
            DM_LyDoNhap dM_LyDoNhap = db.DM_LyDoNhap.Find(id);
            if (dM_LyDoNhap == null)
            {
                return NotFound();
            }

            return Ok(dM_LyDoNhap);
        }

        // PUT: api/DM_LyDoNhapAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_LyDoNhap(int id, DM_LyDoNhap dM_LyDoNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_LyDoNhap.id)
            {
                return BadRequest();
            }

            db.Entry(dM_LyDoNhap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_LyDoNhapExists(id))
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

        // POST: api/DM_LyDoNhapAPI
        [ResponseType(typeof(DM_LyDoNhap))]
        public IHttpActionResult PostDM_LyDoNhap(DM_LyDoNhap dM_LyDoNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_LyDoNhap.Add(dM_LyDoNhap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_LyDoNhap.id }, dM_LyDoNhap);
        }

        // DELETE: api/DM_LyDoNhapAPI/5
        [ResponseType(typeof(DM_LyDoNhap))]
        public IHttpActionResult DeleteDM_LyDoNhap(int id)
        {
            DM_LyDoNhap dM_LyDoNhap = db.DM_LyDoNhap.Find(id);
            if (dM_LyDoNhap == null)
            {
                return NotFound();
            }

            db.DM_LyDoNhap.Remove(dM_LyDoNhap);
            db.SaveChanges();

            return Ok(dM_LyDoNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_LyDoNhapExists(int id)
        {
            return db.DM_LyDoNhap.Count(e => e.id == id) > 0;
        }
    }
}