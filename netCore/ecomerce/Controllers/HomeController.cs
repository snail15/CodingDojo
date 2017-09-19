using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecomerce.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                if(context.Customers.SingleOrDefault(u => u.Name == model.Name) == null){
                    Customer newCustomer = new Customer {
                        Name = model.Name,
                        CreatedAt = DateTime.Now
                    };
                    context.Add(newCustomer);
                    context.SaveChanges();
                    return RedirectToAction("Customers");
                } else {
                    ViewBag.Error = "Duplicate Name Found";
                    ViewBag.Customers = context.Customers.ToList();
                    return View();
                }
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

        [HttpGet]
        [Route("/products")]
        public IActionResult Products(){
            ViewBag.Products = context.Products.ToList();
            return View();
        }

        [HttpPost]
        [Route("/products")]
        public IActionResult Products(ProductViewModel model){

            if(ModelState.IsValid){
                Product newProduct = new Product {
                    Name = model.Name,
                    Image = model.Image,
                    Description = model.Description,
                    Stock = model.Stock,
                    CreatedAt = DateTime.Now
                };
                context.Add(newProduct);
                context.SaveChanges();
                return RedirectToAction("Products");
            }
            ViewBag.Products = context.Products.ToList();
            return View();

        }

        [HttpGet]
        [Route("/orders")]
        public IActionResult Orders(){
            ViewBag.Customers = context.Customers.Include(c => c.Orders).ThenInclude(o => o.Product).ToList();
            ViewBag.Products = context.Products.ToList();
            return View();
        }
        [HttpPost]
        [Route("/orders")]
        public IActionResult Orders(OrderViewModel model){
            if(ModelState.IsValid){
                Order newOrder = new Order {
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId,
                    CreatedAt = DateTime.Now,
                    Quantity = model.Quantity
                };
                context.Add(newOrder);
                context.SaveChanges();
                return RedirectToAction("Orders");
            }
            ViewBag.Customers = context.Customers.Include(c => c.Orders).ThenInclude(o => o.Product).ToList();
            ViewBag.Products = context.Products.ToList();
            return View();
        }

    }
}
