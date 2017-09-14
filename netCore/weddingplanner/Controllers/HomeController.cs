using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using weddingplanner.Models;

namespace weddingplanner.Controllers
{

    public class HomeController : Controller
    {
        private WeddingContext context;

        public HomeController(WeddingContext _context){
            context = _context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
