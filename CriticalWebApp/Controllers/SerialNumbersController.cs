using CriticalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CriticalWebApp.ViewModels;
using System.IO;

namespace CriticalWebApp.Controllers
{
    public class SerialNumbersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: SerialNumbers
        public ActionResult Index(DateTime? startShipDateQuery, DateTime? endShipDateQuery, DateTime? startDateQuery , DateTime? endDateQuery,string serialNumberQuery = null, string customerFirstNameQuery = null, string customerLastNameQuery = null)
        {
            if (startShipDateQuery.HasValue && endShipDateQuery.HasValue)
            {
                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.ShipDate >= startShipDateQuery && s.ShipDate <= endShipDateQuery).ToList().OrderBy(o => o.Number));

            }
            if (!string.IsNullOrEmpty(customerFirstNameQuery) || !string.IsNullOrEmpty(customerLastNameQuery))
            {
                if (!string.IsNullOrEmpty(customerFirstNameQuery) && !string.IsNullOrEmpty(customerLastNameQuery))
                {
                    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.CustomerFirstName.Contains(customerFirstNameQuery) && s.CustomerLastName.Contains(customerLastNameQuery)).ToList().OrderBy(o => o.Number));

                }
                else if (!string.IsNullOrEmpty(customerFirstNameQuery))
                {
                    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.CustomerFirstName.Contains(customerFirstNameQuery)).ToList().OrderBy(o => o.Number));

                }
                else if (!string.IsNullOrEmpty(customerLastNameQuery))
                {
                    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.CustomerLastName.Contains(customerLastNameQuery)).ToList().OrderBy(o => o.Number));

                }

            }




            if (!string.IsNullOrEmpty(serialNumberQuery))
            {
                ViewBag.UserInput = serialNumberQuery;
                int x = 0;
                if (!int.TryParse(serialNumberQuery, out x))
                {
                    if (serialNumberQuery.Length == 2)
                    {
                        return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList().OrderBy(o => o.Number));
                    }
                    else
                    {
                        //format of userinput for itterating through the number
                        int num = 0;
                        string prefix = "";
                        int testNum = 0;

                        //test to find prefix
                        for (int i = 1; i < serialNumberQuery.Length; i++)
                        {
                            string smallString = serialNumberQuery.Substring(serialNumberQuery.Length - (i));
                            bool isNumeric = int.TryParse(smallString, out testNum);
                            if (!isNumeric && testNum == 0)
                            {
                                if (i == 2)
                                {
                                    num = int.Parse(serialNumberQuery.Substring(i));
                                }
                                else
                                {
                                    num = int.Parse(serialNumberQuery.Substring(serialNumberQuery.Length - (i - 1)));
                                }
                                prefix = serialNumberQuery.Remove(serialNumberQuery.Length - num.ToString().Length);
                                serialNumberQuery = prefix + num.ToString("D5");
                                break;
                            }
                        }
                    }

                }
                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList().OrderBy(o => o.Number));

            }

            if (startDateQuery == null || endDateQuery == null)
            {
                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains("xxx")).ToList().OrderBy(o => o.Number));

            }
            ViewBag.StartDate = startDateQuery;
            ViewBag.EndDate = endDateQuery;

            return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.MFGDate >= startDateQuery && s.MFGDate <= endDateQuery).ToList().OrderBy(o => o.Number));
        }

     
        
        public ActionResult Create()
        {
            //string nameCheck = "";
            //string productName = "";
            var viewModel = new CreateSerialNumberViewModel()
            {
                ProductNames = new List<string>(),
                Products = _context.Products.ToList(),
                SerialNumber = new SerialNumber(),
                ProductsCount = _context.Products.Count()
            };
            List<string> productNames = new List<string>(); //gets a list of all product names from db
            foreach (var prodName in viewModel.Products)
            {
                productNames.Add(prodName.Name.ToString());
            }

            List<string> productNamesNoDupes = productNames.Distinct().ToList(); //sofrts through all product names and removed duplicates to add to serialNumberCreateViewModel
            foreach (var p in productNamesNoDupes)
            {
                viewModel.ProductNames.Add(p);
            }
            //foreach (var products in viewModel.Products) //check each product name in the db to pull only unique names. TODO: broke when no in sequence
            //{
                
            //    if (nameCheck != products.Name)
            //    {
            //        viewModel.ProductNames.Add(products.Name);
            //    }
            //    nameCheck = products.Name;
            //}
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSerialNumberViewModel viewModel)
        {
            // if (!ModelState.IsValid)
            // {
            if (viewModel.EndSerialNumber == 0) //for single serial input
            {
                var sn = viewModel.SerialNumber;
                //sn.Product.HardwareRevision = viewModel.Product.HardwareRevision;
                //sn.Product.SoftwareRevision = viewModel.Product.SoftwareRevision;
                var product = _context.Products.Where(p => p.SerialNumberPrefix == viewModel.Product.SerialNumberPrefix &&
                    p.HardwareRevision == viewModel.Product.HardwareRevision &&
                    p.SoftwareRevision == viewModel.Product.SoftwareRevision
                    );

                sn.ProductId = product.First().Id;
                int num = int.Parse(viewModel.SerialNumber.Number);

                sn.Number = product.First().SerialNumberPrefix + num.ToString("D5");
                _context.SerialNumbers.Add(sn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (viewModel.EndSerialNumber >= 1)
                {
                    int beginSerialNumber = int.Parse(viewModel.SerialNumber.Number);
                    for (int i = 0; i < ((viewModel.EndSerialNumber - beginSerialNumber) + 1); i++)
                    {
                        var sn = viewModel.SerialNumber;
                                             
                        var product = _context.Products.Where(p => p.SerialNumberPrefix == viewModel.Product.SerialNumberPrefix && p.HardwareRevision == viewModel.Product.HardwareRevision);
                        sn.ProductId = product.First().Id;
                        int num = beginSerialNumber + i;
                        sn.Number = product.First().SerialNumberPrefix + num.ToString("D5");
                        _context.SerialNumbers.Add(sn);
                        _context.SaveChanges();

                    }
                    return RedirectToAction("Index");
                }
           // }

            return View(viewModel);
        }

        public ActionResult UploadFile()
        {
            Repair repair = new Repair();
            return View(repair);
        }



        [HttpPost]
        public ActionResult UploadFile(Repair repair, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + file.FileName);
                    repair.RouterImagePath = file.FileName;
                }
                _context.Repairs.Add(repair);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repair);
        }
    }
}
