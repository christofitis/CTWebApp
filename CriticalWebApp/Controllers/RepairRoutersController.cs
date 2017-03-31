using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CriticalWebApp.Models;

namespace CriticalWebApp.Controllers
{
    public class RepairRoutersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RepairRouters
        public ActionResult Index(int? rmaNumberQuery, string customerFirstNameQuery = null, string customerLastNameQuery = null)
        {
            if (!string.IsNullOrEmpty(rmaNumberQuery.ToString()))
            {
                return View(db.RepairRouters.Where(r => r.Id == rmaNumberQuery).ToList());
            }
            if (!string.IsNullOrEmpty(customerFirstNameQuery) || !string.IsNullOrEmpty(customerLastNameQuery))
            {
                if (!string.IsNullOrEmpty(customerFirstNameQuery) && !string.IsNullOrEmpty(customerLastNameQuery))
                {
                    return View(db.RepairRouters.Where(s => s.CustomerFirstName.Contains(customerFirstNameQuery) && s.CustomerLastName.Contains(customerLastNameQuery)).ToList().OrderBy(o => o.Id));

                }
                else if (!string.IsNullOrEmpty(customerFirstNameQuery))
                {
                    return View(db.RepairRouters.Where(s => s.CustomerFirstName.Contains(customerFirstNameQuery)).ToList().OrderBy(o => o.Id));

                }
                else if (!string.IsNullOrEmpty(customerLastNameQuery))
                {
                    return View(db.RepairRouters.Where(s => s.CustomerLastName.Contains(customerLastNameQuery)).ToList().OrderBy(o => o.Id));

                }

            }
            return View(db.RepairRouters.ToList());
        }

        // GET: RepairRouters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairRouter repairRouter = db.RepairRouters.Find(id);
            if (repairRouter == null)
            {
                return HttpNotFound();
            }
            return View(repairRouter);
        }

        // GET: RepairRouters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairRouters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairRouter repairRouter)
        {
            if (ModelState.IsValid)
            {
                db.RepairRouters.Add(repairRouter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairRouter);
        }

        // GET: RepairRouters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairRouter repairRouter = db.RepairRouters.Find(id);
            if (repairRouter == null)
            {
                return HttpNotFound();
            }
            return View(repairRouter);
        }

        // POST: RepairRouters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( RepairRouter repairRouter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairRouter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairRouter);
        }

        // GET: RepairRouters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairRouter repairRouter = db.RepairRouters.Find(id);
            if (repairRouter == null)
            {
                return HttpNotFound();
            }
            return View(repairRouter);
        }

        // POST: RepairRouters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairRouter repairRouter = db.RepairRouters.Find(id);
            db.RepairRouters.Remove(repairRouter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
