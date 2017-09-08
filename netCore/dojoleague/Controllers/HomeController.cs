using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojoleague.Models;
using dojoleague.Factories;

namespace dojoleague.Controllers
{
    public class HomeController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        // GET: /Home/
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Index()
        {   
            Ninja newNinja = new Ninja {
                Name = "Sungin",
                Description = "asdsasad",
                Level = 10
            };

            Dojo dojo = dojoFactory.FindByID(1);

            ninjaFactory.Add(newNinja, dojo);
            ViewBag.Ninja = ninjaFactory.FindAll();
            return View();
        }
    }
}
