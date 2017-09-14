using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using weddingplanner2.Models;
using Microsoft.AspNetCore.Identity;

namespace weddingplanner2.Controllers
{
    public class HomeController : Controller
    {

        private WeddingContext context;

        public HomeController(WeddingContext _context)
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

        [HttpPost]
        [Route("")]
        public IActionResult Index(UserViewModel model)
        {
            if(ModelState.IsValid){
                User newUser = new User {
                    Name = model.Name,
                    Email = model.Email
                };
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, model.Password);
                context.Add(newUser);
                context.SaveChanges();
                return View("success");
            } else {
                return View(model);
            }
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login(){
            return View();
        }


    }
}
