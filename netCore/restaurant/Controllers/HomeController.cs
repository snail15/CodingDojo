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

        [HttpPost]
        [Route("")]
        public IActionResult Index(string restaurantname, string name, string date, string review, string star){
    
            DateTime convertedDate = DateTime.ParseExact(date, "yyyy-MM-dd", null);
            System.Console.WriteLine(convertedDate);
            Review createdReview = new Review {
                RestaurantName = restaurantname,
                ReviewerName = name,
                Date = convertedDate,
                Star = star,
                Description = review
            };
            if(ModelState.IsValid){
                context.Add(createdReview);
                context.SaveChanges();
                return RedirectToAction("Review");
            } else {
                return View();
            }

        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Review() {
            List<Review> reviews = context.Reviews.OrderByDescending(review => review.Date).ToList();
            ViewBag.Reviews = reviews;
            return View("success");
        }

    }
}
