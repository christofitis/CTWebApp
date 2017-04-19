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
                OffsiteJob = _context.OffsiteJobs.Include(p => p.AssemblyHouse).FirstOrDefault(o => o.Id == id)

            };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            OffsiteJobCreateViewModel viewModel = new OffsiteJobCreateViewModel()
            {
                AssemblyHouses = _context.AssemblyHouses.ToList(),
                Products = _context.Products.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(OffsiteJobCreateViewModel viewModel)
        {
            //get data from view to add to database
           
                _context.OffsiteJobs.Add(viewModel.OffsiteJob);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
            return View(viewModel);
        }


    }
}