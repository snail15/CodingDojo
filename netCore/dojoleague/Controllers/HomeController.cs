using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojoleague.Factories;
using dojoleague.Models;

namespace dojoleague.Controllers
{
    public class HomeController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;

        public HomeController(){
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Index()
        {   
            ViewBag.Ninjas = ninjaFactory.FindAll();
            ViewBag.Dojos = dojoFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Ninja newNinja){
            if(ModelState.IsValid){
                System.Console.WriteLine("------------Valid---------------");
                ninjaFactory.Add(newNinja);   
                return RedirectToAction("Index");
            } else {
                System.Console.WriteLine("-----Not Valid------");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("dojo/show/{id}")]
        public IActionResult ShowDojo(string id){
            long findId = Int64.Parse(id);
            ViewBag.Dojo = dojoFactory.FindByID(findId);
            return View();
        }

        [HttpGet]
        [Route("ninja/show/{id}")]
        public IActionResult ShowNinja(string id){
            long findId = Int64.Parse(id);
            Ninja showNinja = ninjaFactory.FindByID(findId);
            ViewBag.Ninja = showNinja;
            long dojoId = Int64.Parse(showNinja.DojoId);
            ViewBag.Dojo = dojoFactory.FindByID(dojoId);
            return View();
        }
    }
}
