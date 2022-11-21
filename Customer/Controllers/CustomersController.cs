using Customer.Models;
using Customer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Context _context;
        public CustomersController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var CustomersList = _context.Customers.ToList();
            return View(CustomersList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customers customers)
        {
            _context.Add(customers);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Update(int customerID)
        {
            var data = _context.Customers.Where(x => x.CustomerID == customerID).SingleOrDefault();
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int customerID, Customers customer)
        {
            var data = _context.Customers.FirstOrDefault(x => x.CustomerID == customerID);
            if (data != null)
            {
                data = customer;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int customerID)
        {
            var data = _context.Customers.Find(customerID);
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int customerID, Customers customer)
        {
            var data = _context.Customers.FirstOrDefault(x => x.CustomerID == customerID);
            if (data != null)
            {
                _context.Customers.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag["Error"] = "Not Found";
                return View();
            }
        }
    }
}
