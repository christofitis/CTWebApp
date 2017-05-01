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
using CriticalWebApp.Models;

namespace CriticalWebApp.Controllers.Api
{
    public class OffsiteJobsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/OffsiteJobs
        public IQueryable<OffsiteJob> GetOffsiteJobs()
        {
            return db.OffsiteJobs;
        }

        // GET: api/OffsiteJobs/5
        [ResponseType(typeof(OffsiteJob))]
        public IHttpActionResult GetOffsiteJob(int id)
        {
            OffsiteJob offsiteJob = db.OffsiteJobs.Find(id);
            if (offsiteJob == null)
            {
                return NotFound();
            }

            return Ok(offsiteJob);
        }

        // PUT: api/OffsiteJobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffsiteJob(int id, OffsiteJob offsiteJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offsiteJob.Id)
            {
                return BadRequest();
            }

            db.Entry(offsiteJob).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffsiteJobExists(id))
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

        // POST: api/OffsiteJobs
        [ResponseType(typeof(OffsiteJob))]
        public IHttpActionResult PostOffsiteJob(OffsiteJob offsiteJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OffsiteJobs.Add(offsiteJob);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = offsiteJob.Id }, offsiteJob);
        }

        // DELETE: api/OffsiteJobs/5
        [ResponseType(typeof(OffsiteJob))]
        public IHttpActionResult DeleteOffsiteJob(int id)
        {
            OffsiteJob offsiteJob = db.OffsiteJobs.Find(id);
            if (offsiteJob == null)
            {
                return NotFound();
            }

            db.OffsiteJobs.Remove(offsiteJob);
            db.SaveChanges();

            return Ok(offsiteJob);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OffsiteJobExists(int id)
        {
            return db.OffsiteJobs.Count(e => e.Id == id) > 0;
        }
    }
}