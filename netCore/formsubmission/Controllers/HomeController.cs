using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using formsubmission.Models;

namespace formsubmission.Controllers
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

        [HttpPost]
        [Route("add")]
        public IActionResult Add(string firstname, string lastname, int age, string email, string password) {
            User newUser = new User {
                FirstName = firstname,
                LastName  = lastname,
                Age = age,
                EmailAddress = email,
                Password = password
            };
            System.Console.WriteLine($"------------- {firstname}, {lastname}, {age}, {email}");
            
            TryValidateModel(newUser);
            TempData["errors"] = ModelState.Values.ToString();
            if (TempData["errors"] != null) {
                return RedirectToAction("Index");
            } else {
                return View("success");
            }
        }
    }
}
