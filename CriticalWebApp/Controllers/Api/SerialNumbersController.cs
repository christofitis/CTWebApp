using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CriticalWebApp.Models;
using System.Data.Entity;
using System.Text.RegularExpressions;

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
            return _context.SerialNumbers.ToList().OrderBy(o => o.Number);
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

            var serialNumber = _context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(numberQuery)).ToList();
            if (serialNumber == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return serialNumber;
        }

        public IEnumerable<SerialNumber> GetEstimateSerialNumbers(string estimageNumberQuery)
        {
            int numOfTimesToTry = 0;
            string newHighSerialNumber = incrimentNumberUp(estimageNumberQuery);
            string newLowSerialNumber = incrimentNumberDown(estimageNumberQuery);
            var serialNumbers = new List<SerialNumber>();
            var lowSerialNumbers = _context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(newLowSerialNumber)).ToList().OrderBy(o => o.Number);
            var highSerialNumbers = _context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(newHighSerialNumber)).ToList().OrderBy(o => o.Number);

            while (lowSerialNumbers.Count() <= 0 || highSerialNumbers.Count() <= 0)
            {
                if (highSerialNumbers.Count() <= 0)
                {
                    newHighSerialNumber = incrimentNumberUp(newHighSerialNumber);
                    highSerialNumbers = _context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(newHighSerialNumber)).ToList().OrderBy(o => o.Number);

                }
                if (lowSerialNumbers.Count() <= 0)
                {
                    newLowSerialNumber = incrimentNumberDown(newLowSerialNumber);
                    lowSerialNumbers = _context.SerialNumbers.Include(p => p.Product).Where(s => s.Number.Contains(newLowSerialNumber)).ToList().OrderBy(o => o.Number);

                }
                //if (numOfTimesToTry >= 2)
                //    break;
                numOfTimesToTry++;

                
            }
            if (highSerialNumbers.Count() == 0 || lowSerialNumbers.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            serialNumbers.Add(highSerialNumbers.First());
            serialNumbers.Add(lowSerialNumbers.First());
            if (serialNumbers == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return serialNumbers;
        }

        public IEnumerable<SerialNumber> GetSerialNumbers(DateTime startDate, DateTime endDate)
        {

            var serialNumber = _context.SerialNumbers;
            if (serialNumber == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return serialNumber.Where(s => s.MFGDate >= startDate && s.MFGDate <= endDate).ToList();
            
        }

        private static string incrimentNumberUp(string input)
        {
            input = input + "1"; //adds 1 to input to prevent from ending zeros being deleted on number extraction
            string newSerialNumber = "";
            List<char> array = input.Reverse().ToList();
            string newNum = string.Join("", array);
            string num = (Int32.Parse(Regex.Match(newNum, @"\d+").Value)).ToString();

            string prefix = input.Substring(0, input.Length - num.Length);
            array = num.Reverse().ToList();
            newNum = string.Join("", array).Substring(0, array.Count() - 1);
            newSerialNumber = prefix + (Int32.Parse(newNum) + 1).ToString("00000");
            return newSerialNumber;
        }

        private static string incrimentNumberDown(string input)
        {
            input = input + "1"; //adds 1 to input to prevent from ending zeros being deleted on number extraction
            string newSerialNumber = "";
            List<char> array = input.Reverse().ToList();
            string newNum = string.Join("", array);
            string num = (Int32.Parse(Regex.Match(newNum, @"\d+").Value)).ToString();

            string prefix = input.Substring(0, input.Length - num.Length);
            array = num.Reverse().ToList();
            newNum = string.Join("", array).Substring(0, array.Count() - 1);
            newSerialNumber = prefix + (Int32.Parse(newNum) - 1).ToString("00000");
            return newSerialNumber;
        }

    }
}
