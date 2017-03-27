﻿using System;
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
        public ActionResult Index()
        {
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
        public ActionResult Create([Bind(Include = "Id,ContactDate,ContactedByPhone,ContactedByEmail,TalkedTo,isCODProduct,IsCodMoney,CurrentInQuickbooks,CustomerFirstName,CustomerLastName,ShopName,Phone,Email,Address,Cirt,State,ZipCode,ProdInQB,DateOfPurchase,PlaceOfPurchase,CoveredUnderWarranty,ProductModel,ProductGen,ProductSerialNumber,DidSendAdaptor,IsWarrentyRepair,IsReplaceRepackage,IsReferbishPkg,IsPaidRepair,PaidRepairAmount,ReturnLabel,IsLoggedInQb,ShipType,DateReceived,RMAReceivedBy,IsWithinTheUSA,CustomerComplaint,SpecialInstructions,WasRepaired,WasReplaced,RepairDoneBy,RepairDate,OutSerialNumber,FirstTestDone,FirstTester,SecondTestDone,SecondTester")] RepairRouter repairRouter)
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
        public ActionResult Edit([Bind(Include = "Id,ContactDate,ContactedByPhone,ContactedByEmail,TalkedTo,isCODProduct,IsCodMoney,CurrentInQuickbooks,CustomerFirstName,CustomerLastName,ShopName,Phone,Email,Address,Cirt,State,ZipCode,ProdInQB,DateOfPurchase,PlaceOfPurchase,CoveredUnderWarranty,ProductModel,ProductGen,ProductSerialNumber,DidSendAdaptor,IsWarrentyRepair,IsReplaceRepackage,IsReferbishPkg,IsPaidRepair,PaidRepairAmount,ReturnLabel,IsLoggedInQb,ShipType,DateReceived,RMAReceivedBy,IsWithinTheUSA,CustomerComplaint,SpecialInstructions,WasRepaired,WasReplaced,RepairDoneBy,RepairDate,OutSerialNumber,FirstTestDone,FirstTester,SecondTestDone,SecondTester")] RepairRouter repairRouter)
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
