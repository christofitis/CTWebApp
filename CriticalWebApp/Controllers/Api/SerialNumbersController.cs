using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CriticalWebApp.Models;

namespace CriticalWebApp.Controllers.Api
{
    public class SerialNumbersController : ApiController
    {
        private ApplicationDbContext _context;

        public SerialNumbersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/serialnumbers
        public IEnumerable<SerialNumber> GetSerialNumbers()
        {
            return _context.SerialNumbers.ToList();
        }

        public SerialNumber GetSerialNumber(int id)
        {

            var serialNumber = _context.SerialNumbers.SingleOrDefault(s => s.Id == id);
            if (serialNumber == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return serialNumber;
        }

        public IEnumerable<SerialNumber> GetSerialNumbers(string numberQuery)
        {

            var serialNumber = _context.SerialNumbers;
            if (serialNumber == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return serialNumber.Where(s => s.Number.Contains(numberQuery)).ToList();
        }

    

    }
}
