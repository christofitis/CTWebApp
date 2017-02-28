using CriticalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CriticalWebApp.Controllers.Api
{
    public class RepairsController : ApiController
    {
        private ApplicationDbContext _context;

        public RepairsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Repair> GetRepairs()
        {
            return _context.Repairs.ToList();
        }

        public IEnumerable<Repair> GetRepairs(string customerQuery)
        {
            var repairs = _context.Repairs;
            if (repairs == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            }
            return repairs.Where(r => r.CustomerFirstName.Contains(customerQuery) || r.CustomerLastName.Contains(customerQuery)).ToList();


        }




    }
}
