using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostinthewoods.Factories;

namespace lostinthewoods.Controllers
{
    public class HomeController : Controller
    {

        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = new TrailFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }
    }
}
