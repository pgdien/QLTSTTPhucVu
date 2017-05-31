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
    public class DM_NhomThucDonAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_NhomThucDonAPI
        public IQueryable<DM_NhomThucDon> GetDM_NhomThucDon()
        {
            return db.DM_NhomThucDon;
        }

        // GET: api/DM_NhomThucDonAPI/5
        [ResponseType(typeof(DM_NhomThucDon))]
        public IHttpActionResult GetDM_NhomThucDon(int id)
        {
            DM_NhomThucDon dM_NhomThucDon = db.DM_NhomThucDon.Find(id);
            if (dM_NhomThucDon == null)
            {
                return NotFound();
            }

            return Ok(dM_NhomThucDon);
        }

        // PUT: api/DM_NhomThucDonAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_NhomThucDon(int id, DM_NhomThucDon dM_NhomThucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_NhomThucDon.id)
            {
                return BadRequest();
            }

            db.Entry(dM_NhomThucDon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_NhomThucDonExists(id))
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

        // POST: api/DM_NhomThucDonAPI
        [ResponseType(typeof(DM_NhomThucDon))]
        public IHttpActionResult PostDM_NhomThucDon(DM_NhomThucDon dM_NhomThucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_NhomThucDon.Add(dM_NhomThucDon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_NhomThucDon.id }, dM_NhomThucDon);
        }

        // DELETE: api/DM_NhomThucDonAPI/5
        [ResponseType(typeof(DM_NhomThucDon))]
        public IHttpActionResult DeleteDM_NhomThucDon(int id)
        {
            DM_NhomThucDon dM_NhomThucDon = db.DM_NhomThucDon.Find(id);
            if (dM_NhomThucDon == null)
            {
                return NotFound();
            }

            db.DM_NhomThucDon.Remove(dM_NhomThucDon);
            db.SaveChanges();

            return Ok(dM_NhomThucDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_NhomThucDonExists(int id)
        {
            return db.DM_NhomThucDon.Count(e => e.id == id) > 0;
        }
    }
}