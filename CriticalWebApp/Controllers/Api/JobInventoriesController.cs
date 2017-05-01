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
    public class JobInventoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/JobInventories
        public IQueryable<JobInventory> GetJobInventories()
        {
            return db.JobInventories;
        }

        // GET: api/JobInventories/5
        [ResponseType(typeof(JobInventory))]
        public IHttpActionResult GetJobInventory(int id)
        {
            JobInventory jobInventory = db.JobInventories.Find(id);
            if (jobInventory == null)
            {
                return NotFound();
            }

            return Ok(jobInventory);
        }

        // PUT: api/JobInventories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobInventory(int id, JobInventory jobInventory)
        {
            jobInventory.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobInventory.Id)
            {
                return BadRequest();
            }
       
            

            db.Entry(jobInventory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobInventoryExists(id))
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

        // POST: api/JobInventories
        [ResponseType(typeof(JobInventory))]
        public IHttpActionResult PostJobInventory(JobInventory jobInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobInventories.Add(jobInventory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobInventory.Id }, jobInventory);
        }

        // DELETE: api/JobInventories/5
        [ResponseType(typeof(JobInventory))]
        public IHttpActionResult DeleteJobInventory(int id)
        {
            JobInventory jobInventory = db.JobInventories.Find(id);
            if (jobInventory == null)
            {
                return NotFound();
            }

            db.JobInventories.Remove(jobInventory);
            db.SaveChanges();

            return Ok(jobInventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobInventoryExists(int id)
        {
            return db.JobInventories.Count(e => e.Id == id) > 0;
        }
    }
}