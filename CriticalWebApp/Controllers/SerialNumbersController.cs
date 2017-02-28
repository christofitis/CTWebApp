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
        public ActionResult Index(DateTime? startDateQuery , DateTime? endDateQuery,string serialNumberQuery = null)
        {
            if (!string.IsNullOrEmpty(serialNumberQuery))
            {
                ViewBag.UserInput = serialNumberQuery;
                int x = 0;

                if (!int.TryParse(serialNumberQuery, out x))
                {
                    if (serialNumberQuery.Length == 2)
                    {
                        return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList());

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
                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(serialNumberQuery)).ToList());

            }

            //return View(_context.SerialNumbers.Include(p => p.Product).ToList()); //working that returns entire list of serial numbers
            if (startDateQuery == null || endDateQuery == null)
            {
                return View(_context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains("xxx")).ToList());

            }
            ViewBag.StartDate = startDateQuery;
            ViewBag.EndDate = endDateQuery;

            return View(_context.SerialNumbers.Where(s => s.MFGDate >= startDateQuery && s.MFGDate <= endDateQuery).ToList());
        }

     

        public ActionResult Create()
        {
            string nameCheck = "";
            //string productName = "";
            var viewModel = new CreateSerialNumberViewModel()
            {

                //ProductNames = new List<string>(),
                Products = _context.Products.ToList(),
                SerialNumber = new SerialNumber()
            };
            foreach(var products in viewModel.Products)
            {
                if (nameCheck != products.Name)
                {
                    viewModel.ProductNames.Add(products.Name);
                }
                nameCheck = products.Name;
            }
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSerialNumberViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                

                if (viewModel.EndSerialNumber == 0) //for single serial input
                {
                    var sn = viewModel.SerialNumber;
                    var product = _context.Products.Where(p => p.SerialNumberPrefix == viewModel.Product.SerialNumberPrefix && p.Revision == viewModel.Product.Revision);
                    sn.ProductId = product.First().Id;
                    int num = int.Parse(sn.Number);
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
                                             
                        var product = _context.Products.Where(p => p.SerialNumberPrefix == viewModel.Product.SerialNumberPrefix && p.Revision == viewModel.Product.Revision);
                        sn.ProductId = product.First().Id;
                        int num = beginSerialNumber + i;
                        sn.Number = product.First().SerialNumberPrefix + num.ToString("D5");
                        _context.SerialNumbers.Add(sn);
                        _context.SaveChanges();

                    }
                    return RedirectToAction("Index");
                }
            }

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
