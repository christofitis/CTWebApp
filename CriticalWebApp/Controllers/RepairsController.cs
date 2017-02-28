using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CriticalWebApp.Models;
using CriticalWebApp.ViewModels;

namespace CriticalWebApp.Controllers
{
    public class RepairsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Repairs sends a list of all repairs by date
        public ActionResult Index()
        {
            IndexRepairViewModel viewModel = new IndexRepairViewModel();
            viewModel.Repairs = _context.Repairs.ToList();
            viewModel.CustomerNames = 
            return View(viewModel);

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
    }
}