using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostinthewoods.Factories;
using lostinthewoods.Models;

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

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult Show(string id){
            int findId = Int32.Parse(id);
            ViewBag.Trail = trailFactory.FindByID(findId);
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add(){
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Trail newTrail){
            
            if(ModelState.IsValid){
                trailFactory.Add(newTrail);
                return RedirectToAction("Index");
            } else {
                return View();
            }

        }
    }
}
