using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using weddingplanner2.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

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
                HttpContext.Session.SetInt32("currentUserId", newUser.Id);
                return RedirectToAction("DashBoard");
            } else {
                return View(model);
            }
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password){
            User loginuser = context.Users.SingleOrDefault(user => user.Email == Email);
            List<string> errors = new List<string>();
            if(loginuser == null){
                errors.Add("Invalid Email");
                ViewBag.Errors = errors;
                return View();
            } else{
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if(hasher.VerifyHashedPassword(loginuser, loginuser.Password,Password) != 0){
                    HttpContext.Session.SetInt32("currentUserId", loginuser.Id);
                    return RedirectToAction("DashBoard");
                } else {
                    errors.Add("Invalid Password");
                    ViewBag.Errors = errors;
                    return View();
                }
            }
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult DashBoard(){
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            User currentUser = context.Users.SingleOrDefault(user => user.Id == userId);
            ViewBag.User = currentUser;
            List<Wedding> allWeddings = context.Weddings.ToList();
            ViewBag.Weddings = allWeddings;
            return View();
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(string nameone, string nametwo, string date, string location){
            Wedding newWedding = new Wedding {
                Name = nameone + " & " + nametwo,
                Location = location,
                Date = date
                
            };
            User createdUser = context.Users.SingleOrDefault(user => user.Id == HttpContext.Session.GetInt32("currentUserId"));
            context.Add(newWedding);
            createdUser.WeddingId = newWedding.Id;
            context.SaveChanges();
            return RedirectToAction("DashBoard");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Destroy(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("rsvp")]
        public IActionResult Rsvp(){
            return RedirectToAction("DashBoard");
        }

    }
}
