﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CriticalWebApp.Models;

namespace CriticalWebApp.Controllers
{
    public class RepairsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Repairs sends a list of all repairs by date
        public ActionResult Index(string searchCustomerName = null)
        {
            int counter = 0;
            bool hasWhiteSpace = false;
            if (!string.IsNullOrEmpty(searchCustomerName) && searchCustomerName.Length >= 2)
            {
                foreach (char c in searchCustomerName)
                {
                    if (Char.IsWhiteSpace(c))
                    {
                        hasWhiteSpace = true;
                        break; 
                    }
                    else
                    {
                        counter++;
                    }
                }
                if (hasWhiteSpace)
                {
                    var customerFirstName = searchCustomerName.Remove(counter);
                    var customerLastName = searchCustomerName.Substring(customerFirstName.Length).Replace(" ", string.Empty);
                    var fullNameList = _context.Repairs.Where(r => r.CustomerFirstName.Contains(customerFirstName) && r.CustomerLastName.Contains(customerLastName)).ToList();
                    if (fullNameList.Count == 0)
                    {
                        var repairs = _context.Repairs.Where(r => r.CustomerFirstName.Contains(searchCustomerName)).ToList();
                        var lastNameQuery = _context.Repairs.Where(r => r.CustomerLastName.Contains(searchCustomerName)).ToList();
                        foreach (var name in lastNameQuery)
                        {
                            repairs.Add(name);
                        }
                        return View(repairs);
                    }
                    return View(fullNameList);
                }
                else
                {
                    var repairs = _context.Repairs.Where(r => r.CustomerFirstName.Contains(searchCustomerName)).ToList();
                    var lastNameQuery = _context.Repairs.Where(r => r.CustomerLastName.Contains(searchCustomerName)).ToList();
                    foreach (var name in lastNameQuery)
                    {
                        repairs.Add(name);
                    }
                        return View(repairs);
                }
            }
            return View(_context.Repairs.ToList().OrderByDescending(o => o.Id));
        }

        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                Repair repair = _context.Repairs.Find(id);
                return View(repair);
            }
            return HttpNotFound();
        }



        public ActionResult Create()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Repair repair)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/App_Data/UploadedFiles")
                                                          + file.FileName);
                    repair.RouterImagePath = file.FileName;
                }
                _context.Repairs.Add(repair);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            Repair repair = _context.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        [HttpPost]
        public ActionResult Edit(Repair repair)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(repair).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return HttpNotFound();
        }



    }
}