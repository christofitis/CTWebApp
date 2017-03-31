using CriticalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CriticalWebApp.Controllers
{
    public class SqlCommanderController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: SqlCommander
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Run(string sqlCommand)
        {
            _context.Database.ExecuteSqlCommand(sqlCommand);
            return RedirectToAction("Index");
        }
    }
}