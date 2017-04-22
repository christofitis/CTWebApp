using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CriticalWebApp.Models;
using System.Net;
using System.Data.Entity;
using CriticalWebApp.ViewModels;

namespace CriticalWebApp.Controllers
{
    public class OffsiteJobController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: OffsiteJob
        public ActionResult Index()
        {
            var offsiteJobs = _context.OffsiteJobs.Include(p => p.Product).Include(a => a.AssemblyHouse).ToList().OrderByDescending(o => o.Id);
            return View(offsiteJobs);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new OffsiteJobDetailsViewModel()
            {
                JobInventories = _context.JobInventories.Include(p => p.Part).Include(p => p.OffsiteJob).Where(o => o.OffsiteJobId == id),
                OffsiteJob = _context.OffsiteJobs.Include(p => p.AssemblyHouse).Include(p => p.Product).FirstOrDefault(o => o.Id == id)

            };  
            
            return View(viewModel);
        }

        public ActionResult Create()
        {
            OffsiteJobCreateViewModel viewModel = new OffsiteJobCreateViewModel();
            List<string> productNames = new List<string>(); //gets a list of all product names from db


            foreach (var ah in _context.AssemblyHouses)
            {
                viewModel.AssemblyHouses.Add(ah.Name);
            }
            foreach (var prod in _context.Products)
            {
                productNames.Add(prod.Name);
            }
            List<string> productNamesNoDupes = productNames.Distinct().ToList();
            foreach (var p in productNamesNoDupes)
            {
                viewModel.Products.Add(p);
            }


            return View();
        }

        [HttpPost]
        public ActionResult Create(OffsiteJobCreateViewModel viewModel)
        {
            var offsiteJob = new OffsiteJob();

            var product = new Product();
            product = _context.Products.Where(a => a.Name == viewModel.OffsiteJob.Product.Name).FirstOrDefault();

            var assemblyHouse = new AssemblyHouse();
            assemblyHouse = _context.AssemblyHouses.Where(a => a.Name == viewModel.OffsiteJob.AssemblyHouse.Name).FirstOrDefault();

            viewModel.OffsiteJob.AssemblyHouseId = assemblyHouse.Id;
            viewModel.OffsiteJob.ProductId = product.Id;
            viewModel.OffsiteJob.Product = product;
            viewModel.OffsiteJob.AssemblyHouse = assemblyHouse;
            

            _context.OffsiteJobs.Add(viewModel.OffsiteJob);
                _context.SaveChanges();
            return RedirectToAction("Kit");


        }


    }
}