using CriticalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CriticalWebApp.ViewModels;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;


namespace CriticalWebApp.Controllers
{
    public class SerialNumbersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: SerialNumbers
        //TODO: Build list of objects then return that to view (will allow for multiple searches to be added together), not return per input. 
        //public ActionResult Index( DateTime? startShipDateQuery, DateTime? endShipDateQuery, DateTime? startDateQuery, DateTime? endDateQuery,IEnumerable<SerialNumber> newEntries = null, string serialNumberQuery = null, string customerFirstNameQuery = null, string customerLastNameQuery = null, string invoiceNumberQuery = null)
        //{
        //    if (newEntries != null)
        //    {
        //        return View(newEntries.ToList());
        //    }
        //    if (!string.IsNullOrEmpty(invoiceNumberQuery))
        //    {
        //        ViewBag.InvoiceNumber = invoiceNumberQuery;
        //        return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.InvoiceNumber.Contains(invoiceNumberQuery)).ToList().OrderBy(o => o.Number));
        //    }

        //    if (!string.IsNullOrEmpty(serialNumberQuery))
        //        ViewBag.SerialNumber = serialNumberQuery;

        //    if (startDateQuery.HasValue)
        //        ViewBag.StartMFGDate = startDateQuery.Value.ToString("d");

        //    if (endDateQuery.HasValue)
        //        ViewBag.EndMFGDate = endDateQuery.Value.ToString("d");
        //    if (startShipDateQuery.HasValue)
        //        ViewBag.StartShipDate = startShipDateQuery.Value.ToString("d");
        //    if (endShipDateQuery.HasValue)
        //        ViewBag.EndShipDate = endShipDateQuery.Value.ToString("d");
        //    if (!string.IsNullOrEmpty(customerFirstNameQuery))
        //        ViewBag.CustomerFirstName = customerFirstNameQuery;
        //    if (!string.IsNullOrEmpty(customerLastNameQuery))
        //        ViewBag.CustomerLastName = customerLastNameQuery;

        //    if (startShipDateQuery.HasValue && endShipDateQuery.HasValue)
        //    {
        //        return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.ShipDate >= startShipDateQuery && s.ShipDate <= endShipDateQuery).ToList().OrderBy(o => o.Number));

        //    }
        //    if (!string.IsNullOrEmpty(customerFirstNameQuery) || !string.IsNullOrEmpty(customerLastNameQuery))
        //    {
        //        if (!string.IsNullOrEmpty(customerFirstNameQuery) && !string.IsNullOrEmpty(customerLastNameQuery))
        //        {
        //            return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.CustomerFirstName.Contains(customerFirstNameQuery) && s.CustomerLastName.Contains(customerLastNameQuery)).ToList().OrderBy(o => o.Number));

        //        }
        //        else if (!string.IsNullOrEmpty(customerFirstNameQuery))
        //        {
        //            return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.CustomerFirstName.Contains(customerFirstNameQuery)).ToList().OrderBy(o => o.Number));

        //        }
        //        else if (!string.IsNullOrEmpty(customerLastNameQuery))
        //        {
        //            return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.CustomerLastName.Contains(customerLastNameQuery)).ToList().OrderBy(o => o.Number));

        //        }

        //    }

        //    if (startDateQuery.HasValue && endDateQuery.HasValue)
        //        return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.MFGDate >= startDateQuery && s.MFGDate <= endDateQuery).ToList().OrderBy(o => o.Number));





        //    //-------------------serialNumberQuery------------------------------
        //    if (!string.IsNullOrEmpty(serialNumberQuery))
        //    {
        //        int intTest = 0;
        //        int endNumberTest = 0;
        //        int.TryParse(serialNumberQuery.Substring(serialNumberQuery.Length - 1), out endNumberTest);

        //        int.TryParse(serialNumberQuery, out intTest);
        //        if (intTest == 0 && endNumberTest != 0)
        //        {
        //            if (serialNumberQuery.Length < 3)
        //            {
        //                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList().OrderBy(o => o.Number));
        //            }
        //            else if (serialNumberQuery.Length == 3 && intTest == 0)
        //            {
        //                int.TryParse(serialNumberQuery.Substring(2), out intTest);
        //                if (intTest == 0)
        //                    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList().OrderBy(o => o.Number));
        //                else
        //                {
        //                    string number = Regex.Match(serialNumberQuery.Substring(1), @"\d+").Value;
        //                    string prefix = serialNumberQuery.Substring(0, serialNumberQuery.Length - number.Length);
        //                    string formattedSerialNumber = prefix + int.Parse(number).ToString("D5");
        //                    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(formattedSerialNumber)).ToList().OrderBy(o => o.Number));
        //                }
        //            }
        //            else
        //            {
        //                string number = Regex.Match(serialNumberQuery.Substring(1), @"\d+").Value;
        //                string prefix = serialNumberQuery.Substring(0, serialNumberQuery.Length - number.Length);
        //                string formattedSerialNumber = prefix + int.Parse(number).ToString("D5");
        //                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(formattedSerialNumber)).ToList().OrderBy(o => o.Number));
        //            }
        //        }
        //        return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList().OrderBy(o => o.Number));
        //    }
        //    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains("xxx")).ToList().OrderBy(o => o.Number));
        //    //---------------------------------------------------------------------------


        //}

        public ActionResult Index(DateTime? startShipDateQuery, DateTime? endShipDateQuery, DateTime? startDateQuery, DateTime? endDateQuery, IEnumerable<SerialNumber> newEntries = null, string serialNumberQuery = null, string customerFirstNameQuery = null, string customerLastNameQuery = null, string invoiceNumberQuery = null)
        {
            var serialNumbers = new List<SerialNumber>();

            if (!string.IsNullOrWhiteSpace(serialNumberQuery))
            {
                int testValue = 0;
                int.TryParse(serialNumberQuery, out testValue);
                if (testValue != 0)
                {
                    return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList());
                }
                
            }



            return View(serialNumbers);
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

            List<string> productNamesNoDupes = productNames.Distinct().OrderBy(p => p).ToList(); //sofrts through all product names and removed duplicates to add to serialNumberCreateViewModel
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
            var snToReturnToView = new List<SerialNumber>();
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
                snToReturnToView.Add(sn);
                return RedirectToAction("Create");
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
                    snToReturnToView.Add(sn);
                    }
                    return RedirectToAction("Create");
                }
           // }

            return View(viewModel);
        }

        public ActionResult LogShipment()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult LogShipment(LogShipmentViewModel viewModel)
        {
            var sns = _context.SerialNumbers.Where(s => viewModel.SerialNumberIds.Contains(s.Id));
            foreach (var sn in sns)
            {
                
                sn.CustomerFirstName = viewModel.CustomerFirstName;
                sn.CustomerLastName = viewModel.CustomerLastName;
                sn.ShipDate = viewModel.Shipdate;
                sn.InvoiceNumber = viewModel.InvoiceNumber;
                _context.Entry(sn).State = EntityState.Modified;
                
            }
            _context.SaveChanges();
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SerialNumber serialNumber = _context.SerialNumbers.Include(p => p.Product).FirstOrDefault(p => p.Id == id);
            if (serialNumber == null)
            {
                return HttpNotFound();
            }

            return View(serialNumber);
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
