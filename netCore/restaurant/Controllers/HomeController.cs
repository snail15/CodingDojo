using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restaurant.Models;
using System.Linq;

namespace restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext context;

        public HomeController(RestaurantContext _context) {
            context = _context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Review> reviews = context.Reviews.ToList();
            ViewBag.Reviews = reviews;
            return View();
        }
    }
}
