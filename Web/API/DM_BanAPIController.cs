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
    public class DM_BanAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_BanAPI
        public IQueryable<DM_Ban> GetDM_Ban()
        {
            return db.DM_Ban.OrderBy(p => p.ten);
        }

        // GET: api/DM_BanAPI/5
        [ResponseType(typeof(DM_Ban))]
        public IHttpActionResult GetDM_Ban(int id)
        {
            DM_Ban dM_Ban = db.DM_Ban.Find(id);
            if (dM_Ban == null)
            {
                return NotFound();
            }

            return Ok(dM_Ban);
        }

        // GET: api/DM_BanAPI?att=...&&value=...
        [ResponseType(typeof(DM_Ban))]
        public IQueryable<DM_Ban> GetDM_Ban(string att, string value)
        {
            var model = db.DM_Ban;

            if (att == "idKhuVuc")
            {
                int idKhuVuc = Int32.Parse(value);
                var bans = db.DM_Ban.Where(p => p.idKhuVuc == idKhuVuc).OrderBy(p => p.ten);
                return bans;
            }

            return model;
        }

        // PUT: api/DM_BanAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_Ban(int id, DM_Ban dM_Ban)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_Ban.id)
            {
                return BadRequest();
            }

            db.Entry(dM_Ban).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_BanExists(id))
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

        // POST: api/DM_BanAPI
        [ResponseType(typeof(DM_Ban))]
        public IHttpActionResult PostDM_Ban(DM_Ban dM_Ban)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_Ban.Add(dM_Ban);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_Ban.id }, dM_Ban);
        }

        // DELETE: api/DM_BanAPI/5
        [ResponseType(typeof(DM_Ban))]
        public IHttpActionResult DeleteDM_Ban(int id)
        {
            DM_Ban dM_Ban = db.DM_Ban.Find(id);
            if (dM_Ban == null)
            {
                return NotFound();
            }

            db.DM_Ban.Remove(dM_Ban);
            db.SaveChanges();

            return Ok(dM_Ban);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_BanExists(int id)
        {
            return db.DM_Ban.Count(e => e.id == id) > 0;
        }
    }
}