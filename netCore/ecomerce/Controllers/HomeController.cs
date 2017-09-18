using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecomerce.Models;
using System.Linq;

namespace ecomerce.Controllers
{
    public class HomeController : Controller
    {

        private CommerceContext context;

        public HomeController(CommerceContext _context)
        {
            context = _context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/customers")]
        public IActionResult Customers(){
            List<Customer> allCustomers = context.Customers.ToList();
            foreach(var customer in allCustomers){
                System.Console.WriteLine("****************");
                System.Console.WriteLine(customer.Name);
            }
            ViewBag.Customers = allCustomers;
            return View();
        }
    
        [HttpPost]
        [Route("/customers")]
        public IActionResult Customers(CustomerViewModel model){

            if(ModelState.IsValid){
                Customer newCustomer = new Customer {
                    Name = model.Name,
                    CreatedAt = DateTime.Now
                };
                context.Add(newCustomer);
                context.SaveChanges();
                return RedirectToAction("Customers");
            }
            ViewBag.Customers = context.Customers.ToList();
            return View();
        }

        [HttpGet]
        [Route("customers/remove/{id}")]
        public IActionResult RemoveCustomer(string id){
            int findId = Int32.Parse(id);
            Customer deletedCustomer = context.Customers.SingleOrDefault(c => c.Id == findId);
            context.Remove(deletedCustomer);
            context.SaveChanges();
            return RedirectToAction("Customers");
        }

    }
}
