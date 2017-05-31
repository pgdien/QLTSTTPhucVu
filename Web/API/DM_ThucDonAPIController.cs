using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Web.Models;

namespace Web.API
{
    public class DM_ThucDonAPIController : ApiController
    {
        private Karaoke2017Entities db = new Karaoke2017Entities();

        // GET: api/DM_ThucDonAPI
        public IQueryable<DM_ThucDon> GetDM_ThucDon()
        {
            return db.DM_ThucDon.OrderBy(p => p.ten);
        }

        // GET: api/DM_ThucDonAPI/5
        [ResponseType(typeof(DM_ThucDon))]
        public IHttpActionResult GetDM_ThucDon(int id)
        {
            DM_ThucDon dM_ThucDon = db.DM_ThucDon.Find(id);
            if (dM_ThucDon == null)
            {
                return NotFound();
            }

            return Ok(dM_ThucDon);
        }

        //GET: API/DM_ThucDonAPI?att=...
        [ResponseType(typeof(DM_ThucDon))]
        public async Task<DM_ThucDon> GetDM_ThucDon(string att)
        {
            DM_ThucDon dM_ThucDon = db.DM_ThucDon.OrderByDescending(p => p.id).FirstOrDefault();

            if (att == "getSPCuoi" && att != null)
            {
                var model = db.DM_ThucDon.OrderByDescending(p => p.id).FirstOrDefault();
                return model;
            }

            return dM_ThucDon;


        }

        // GET: api/DM_ThucDonAPI?att=...&&value=...
        [ResponseType(typeof(DM_ThucDon))]
        public IQueryable<DM_ThucDon> GetDM_ThucDon(string att, string value)
        {
            var model = db.DM_ThucDon;

            if (att == "idNhomThucDon")
            {
                int idNhomThucDon = Int32.Parse(value);
                var thucdons = db.DM_ThucDon.Where(p => p.idNhomThucDon == idNhomThucDon).OrderBy(p => p.ten);
                return thucdons;
            }

            return model;
        }

        // PUT: api/DM_ThucDonAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_ThucDon(int id, DM_ThucDon dM_ThucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_ThucDon.id)
            {
                return BadRequest();
            }

            db.Entry(dM_ThucDon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_ThucDonExists(id))
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

        // POST: api/DM_ThucDonAPI
        [ResponseType(typeof(DM_ThucDon))]
        public IHttpActionResult PostDM_ThucDon(DM_ThucDon dM_ThucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_ThucDon.Add(dM_ThucDon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_ThucDon.id }, dM_ThucDon);
        }

        // DELETE: api/DM_ThucDonAPI/5
        [ResponseType(typeof(DM_ThucDon))]
        public IHttpActionResult DeleteDM_ThucDon(int id)
        {
            DM_ThucDon dM_ThucDon = db.DM_ThucDon.Find(id);
            if (dM_ThucDon == null)
            {
                return NotFound();
            }

            db.DM_ThucDon.Remove(dM_ThucDon);
            db.SaveChanges();

            return Ok(dM_ThucDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_ThucDonExists(int id)
        {
            return db.DM_ThucDon.Count(e => e.id == id) > 0;
        }
    }
}