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
    public class AssemblyHousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssemblyHouses
        public ActionResult Index()
        {
            return View(db.AssemblyHouses.ToList());
        }

        // GET: AssemblyHouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyHouse assemblyHouse = db.AssemblyHouses.Find(id);
            if (assemblyHouse == null)
            {
                return HttpNotFound();
            }
            return View(assemblyHouse);
        }

        // GET: AssemblyHouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssemblyHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Notes")] AssemblyHouse assemblyHouse)
        {
            if (ModelState.IsValid)
            {
                db.AssemblyHouses.Add(assemblyHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assemblyHouse);
        }

        // GET: AssemblyHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyHouse assemblyHouse = db.AssemblyHouses.Find(id);
            if (assemblyHouse == null)
            {
                return HttpNotFound();
            }
            return View(assemblyHouse);
        }

        // POST: AssemblyHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Notes")] AssemblyHouse assemblyHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assemblyHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assemblyHouse);
        }

        // GET: AssemblyHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyHouse assemblyHouse = db.AssemblyHouses.Find(id);
            if (assemblyHouse == null)
            {
                return HttpNotFound();
            }
            return View(assemblyHouse);
        }

        // POST: AssemblyHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssemblyHouse assemblyHouse = db.AssemblyHouses.Find(id);
            db.AssemblyHouses.Remove(assemblyHouse);
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
