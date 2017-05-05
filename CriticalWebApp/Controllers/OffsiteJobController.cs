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
            List<string> productNamesNoDupes = productNames.Distinct().OrderBy(p => p).ToList();
            foreach (var p in productNamesNoDupes)
            {
                viewModel.Products.Add(p);
            }
            viewModel.AllProducts = _context.Products.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(OffsiteJobCreateViewModel viewModel, string hardwareRevisionDropDown = null)
        {
            var offsiteJob = new OffsiteJob();

            var product = new Product();
            product = _context.Products.Where(a => a.Name == viewModel.OffsiteJob.Product.Name && a.HardwareRevision == hardwareRevisionDropDown).FirstOrDefault();

            var assemblyHouse = new AssemblyHouse();
            assemblyHouse = _context.AssemblyHouses.Where(a => a.Name == viewModel.OffsiteJob.AssemblyHouse.Name).FirstOrDefault();

            viewModel.OffsiteJob.AssemblyHouseId = assemblyHouse.Id;
            viewModel.OffsiteJob.ProductId = product.Id;
            viewModel.OffsiteJob.Product = product;
            viewModel.OffsiteJob.AssemblyHouse = assemblyHouse;
            

            _context.OffsiteJobs.Add(viewModel.OffsiteJob);
                _context.SaveChanges();
            _context.Entry(viewModel.OffsiteJob).GetDatabaseValues();

            int id = viewModel.OffsiteJob.Id;
            createJobInventoriesForJob(id);


            return RedirectToAction("CreateKit", new {id = id});


        }


        //class to create jobinventories per job po for the product selected
        private void createJobInventoriesForJob(int id) 
        {
            var offsiteJob = _context.OffsiteJobs.FirstOrDefault(j => j.Id == id);
            var product = _context.Products.FirstOrDefault(o => o.Id == offsiteJob.ProductId);
            var viewModel = new OffsiteJobDetailsViewModel()
            {
                JobInventories = _context.JobInventories.Include(p => p.Part).Include(p => p.OffsiteJob).Where(o => o.OffsiteJobId == id),
                OffsiteJob = _context.OffsiteJobs.Include(p => p.AssemblyHouse).Include(p => p.Product).FirstOrDefault(o => o.Id == id),
                ProductAssemblies = _context.ProductAssemblies.Include(p => p.Part).Where(a => a.ProductId == product.Id && a.Part.Category == "Electronics SMT").ToList()

            };

            //auto creates part list in database but double does it if someone refreshes page
            foreach (var part in viewModel.ProductAssemblies)
            {
                var jobInventory = new JobInventory();
                jobInventory.OffsiteJobId = viewModel.OffsiteJob.Id;
                jobInventory.PartId = part.PartId;
                jobInventory.QuantityAtJobSite = 0;
                _context.JobInventories.Add(jobInventory);


                _context.SaveChanges();

            }
        }

     

        public ActionResult CreateKit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var offsiteJob = _context.OffsiteJobs.FirstOrDefault(j => j.Id == id);
            var product = _context.Products.FirstOrDefault(o => o.Id == offsiteJob.ProductId);
            var viewModel = new OffsiteJobDetailsViewModel()
            {
                JobInventories = _context.JobInventories.Include(p => p.Part).Include(p => p.OffsiteJob).Where(o => o.OffsiteJobId == id),
                OffsiteJob = _context.OffsiteJobs.Include(p => p.AssemblyHouse).Include(p => p.Product).FirstOrDefault(o => o.Id == id),
                ProductAssemblies = _context.ProductAssemblies.Include(p => p.Part).Where(a => a.ProductId == product.Id && a.Part.Category == "Electronics SMT").ToList()

            };
            return View(viewModel);


        }


        public ActionResult Receive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var offsiteJob = _context.OffsiteJobs.FirstOrDefault(j => j.Id == id);
            var product = _context.Products.FirstOrDefault(o => o.Id == offsiteJob.ProductId);
            var viewModel = new OffsiteJobDetailsViewModel()
            {
                JobInventories = _context.JobInventories.Include(p => p.Part).Include(p => p.OffsiteJob).Where(o => o.OffsiteJobId == id),
                OffsiteJob = _context.OffsiteJobs.Include(p => p.AssemblyHouse).Include(p => p.Product).FirstOrDefault(o => o.Id == id),
                ProductAssemblies = _context.ProductAssemblies.Include(p => p.Part).Where(a => a.ProductId == product.Id && a.Part.Category == "Electronics SMT").ToList()

            };
            return View(viewModel);
        }

        public ActionResult PartsSummary()
        {
            
            var viewModel = _context.JobInventories.Include(p => p.Part).ToList();
            var parts = viewModel.GroupBy(i => new {i.PartId, i.Part.Name, i.QuantityAtJobSite });
                
            return View(parts);
        }


    }
}