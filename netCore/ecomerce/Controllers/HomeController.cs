using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecomerce.Models;

namespace ecomerce.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
        }
        [HttpPost]
        [Route("/customers")]
        public IActionResult Customers(CustomerViewModel model){
            return View();
        }


    }
}
