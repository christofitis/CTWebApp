using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CriticalWebApp.Models;
using CriticalWebApp.ViewModels;

namespace CriticalWebApp.Controllers
{
    public class ProductionOutputTotalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductionOutputTotals
        public ActionResult Index()
        {
            var viewModel =  new ProductionOutputTotalsViewModel();
            viewModel.Products = db.Products.ToList();
            List<string> uniqueProducts = db.Products.Select(p => p.Name).Distinct().ToList(); //entire listof products sent to view model
            viewModel.ProductionOutputTotals = db.ProductionOutputTotals.ToList(); //list of all production totals in db
            
            foreach (var product in uniqueProducts)
            {
                var productionAverageTotals = new ProductionAverageTotals();
               
                var singleProductTotals = db.ProductionOutputTotals.Where(t => t.Product.Name == product).ToList(); //fills list object with production totalls matching product name

                for (int i = 0; i < singleProductTotals.Count; i++)
                {


                    productionAverageTotals.Quantity += singleProductTotals[i].Quantity;
                    productionAverageTotals.Product = singleProductTotals[i].Product.Name;

                }

                viewModel.ProductionAverageTotals.Add(productionAverageTotals);
            }
            
            
            //TODO: add math to figure out production totals for month using linq entityframework
         
            //productionAverageTotals = db.ProductionOutputTotals.
            //viewModel.ProductionAverageTotals.Add();
            
            return View(viewModel);
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
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");
            return View();
        }

        // POST: ProductionOutputTotals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,Employee,Quantity,Notes")] ProductionOutputTotals productionOutputTotals)
        {
            if (ModelState.IsValid)
            {
                db.ProductionOutputTotals.Add(productionOutputTotals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", productionOutputTotals.ProductId);
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
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", productionOutputTotals.ProductId);
            return View(productionOutputTotals);
        }

        // POST: ProductionOutputTotals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,Employee,Quantity,Notes")] ProductionOutputTotals productionOutputTotals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionOutputTotals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", productionOutputTotals.ProductId);
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
