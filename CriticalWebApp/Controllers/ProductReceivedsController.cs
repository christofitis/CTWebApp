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
    public class ProductReceivedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductReceiveds
        public ActionResult Index()
        {
            return View(db.ProductReceived.ToList());
        }

        // GET: ProductReceiveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReceived productReceived = db.ProductReceived.Find(id);
            if (productReceived == null)
            {
                return HttpNotFound();
            }
            return View(productReceived);
        }

        // GET: ProductReceiveds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductReceiveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReceivedDate,Employee,NumberOfBoxes,QuantityOnBox,CountedQuantity,ReferenceNumber,Notes")] ProductReceived productReceived)
        {
            if (ModelState.IsValid)
            {
                db.ProductReceived.Add(productReceived);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productReceived);
        }

        // GET: ProductReceiveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReceived productReceived = db.ProductReceived.Find(id);
            if (productReceived == null)
            {
                return HttpNotFound();
            }
            return View(productReceived);
        }

        // POST: ProductReceiveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReceivedDate,Employee,NumberOfBoxes,QuantityOnBox,CountedQuantity,ReferenceNumber,Notes")] ProductReceived productReceived)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productReceived).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productReceived);
        }

        // GET: ProductReceiveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReceived productReceived = db.ProductReceived.Find(id);
            if (productReceived == null)
            {
                return HttpNotFound();
            }
            return View(productReceived);
        }

        // POST: ProductReceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductReceived productReceived = db.ProductReceived.Find(id);
            db.ProductReceived.Remove(productReceived);
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
