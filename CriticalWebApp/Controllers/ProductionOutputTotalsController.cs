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
    public class ProductionOutputTotalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductionOutputTotals
        public ActionResult Index()
        {
            return View(db.ProductionOutputTotals.ToList());
        }

        // GET: ProductionOutputTotals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionOutputTotals productionOutputTotals = db.ProductionOutputTotals.Find(id);
            if (productionOutputTotals == null)
            {
                return HttpNotFound();
            }
            return View(productionOutputTotals);
        }

        // GET: ProductionOutputTotals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionOutputTotals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Product,Employee,Quantity,Notes")] ProductionOutputTotals productionOutputTotals)
        {
            if (ModelState.IsValid)
            {
                db.ProductionOutputTotals.Add(productionOutputTotals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionOutputTotals);
        }

        // GET: ProductionOutputTotals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionOutputTotals productionOutputTotals = db.ProductionOutputTotals.Find(id);
            if (productionOutputTotals == null)
            {
                return HttpNotFound();
            }
            return View(productionOutputTotals);
        }

        // POST: ProductionOutputTotals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Product,Employee,Quantity,Notes")] ProductionOutputTotals productionOutputTotals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionOutputTotals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionOutputTotals);
        }

        // GET: ProductionOutputTotals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionOutputTotals productionOutputTotals = db.ProductionOutputTotals.Find(id);
            if (productionOutputTotals == null)
            {
                return HttpNotFound();
            }
            return View(productionOutputTotals);
        }

        // POST: ProductionOutputTotals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionOutputTotals productionOutputTotals = db.ProductionOutputTotals.Find(id);
            db.ProductionOutputTotals.Remove(productionOutputTotals);
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
