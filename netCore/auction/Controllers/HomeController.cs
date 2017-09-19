using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using auction.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace auction.Controllers
{
    public class HomeController : Controller
    {

        private AuctionContext context;

        public HomeController(AuctionContext _context)
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
        public IActionResult Index(UserModelView model)
        {
            if(ModelState.IsValid){
                User newUser = new User {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Wallet = 1000,
                    Username = model.Username,
                    CreatedAt = DateTime.Now
                };
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, model.Password);
                context.Add(newUser);
                context.SaveChanges();
                HttpContext.Session.SetInt32("currentUserId", newUser.Id);
                    HttpContext.Session.SetString("currentUserName", newUser.FirstName);
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string username, string password){
            User loginuser = context.Users.SingleOrDefault(user => user.Username == username);
            if(loginuser == null){
                ViewBag.UsernameError = "Invalid Username! Typo?";
                return View();
            } else{
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if(hasher.VerifyHashedPassword(loginuser, loginuser.Password, password) != 0){
                    HttpContext.Session.SetInt32("currentUserId", loginuser.Id);
                    HttpContext.Session.SetString("currentUserName", loginuser.FirstName);
                    return RedirectToAction("Dashboard");
                } else {
                    ViewBag.PasswordError = "Invlaid Password! Typo?";
                    return View();
                }
            }
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard(){
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            User currentUser = context.Users.SingleOrDefault(u => u.Id == (int)userId);
            List<Auction> allAuctions = context.Auctions.ToList();
            ViewBag.User = currentUser;
            ViewBag.Auctions = allAuctions;
            Dictionary<int, int> remainingTime = new Dictionary<int, int>();
            DateTime now = DateTime.Now;
            foreach(var auction in allAuctions){
                remainingTime[auction.Id] = (auction.EndDate - now).Days;
            }
            ViewBag.Reamining = remainingTime;
            return View();
        }

        [HttpGet]
        [Route("/createauction")]
        public IActionResult CreateAuction(){
            return View();
        }
        [HttpPost]
        [Route("/createauction")]
        public IActionResult CreateAuction(AuctionViewModel model){
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            User currentUser = context.Users.SingleOrDefault(u => u.Id == (int)userId);
            if(ModelState.IsValid){
                Auction newAuction = new Auction {
                    ProductName = model.ProductName,
                    CreatedUser = currentUser.FirstName + " " + currentUser.LastName,
                    Description = model.Description,
                    Bid = model.Bid,
                    EndDate = DateTime.Parse(model.EndDate),
                    CreatedAt = DateTime.Now
                };
                context.Add(newAuction);
                context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpGet]
        [Route("/auction/{id}")]
        public IActionResult ShowAuction(string id){
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            User currentUser = context.Users.SingleOrDefault(u => u.Id == (int)userId);
            int auctionId = Int32.Parse(id);
            Auction showingAuction = context.Auctions.SingleOrDefault(a => a.Id == auctionId);
            ViewBag.Auction = showingAuction;
            ViewBag.User = currentUser;
            return View();
        }
        [HttpPost]
        [Route("/auction/{id}")]
        public IActionResult ShowAuction(string id, string bid){

            List<string> errors = new List<string>();
            int auctionId = Int32.Parse(id);
            Auction showingAuction = context.Auctions.SingleOrDefault(a => a.Id == auctionId);
            if(bid != null){
               
                int bidAmount = Int32.Parse(bid);


                int? userId = HttpContext.Session.GetInt32("currentUserId");
                User currentUser = context.Users.SingleOrDefault(u => u.Id == (int)userId);

                if(bidAmount <= showingAuction.Bid){
                    errors.Add("Has to be more than current bid");
                    ViewBag.AmountErrors = errors;
                    ViewBag.Auction = showingAuction;
                    return View();
                } else if(bidAmount > currentUser.Wallet) {
                    errors.Add("You don't even have money");
                    ViewBag.AmountErrors = errors;
                    ViewBag.Auction = showingAuction;
                    return View();
                } else {
                    showingAuction.Bid = bidAmount;
                    showingAuction.HighestBidder = currentUser.FirstName;
                    currentUser.Wallet -= bidAmount;
                    context.SaveChanges();
                    return RedirectToAction("ShowAuction");
                }
            } else {
                errors.Add("Did you forget?");
                ViewBag.AmountErrors = errors;
                ViewBag.Auction = showingAuction;
                return View();
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/auction/delete/{id}")]
        public IActionResult DeleteAuction(string id){
            int auctionId = Int32.Parse(id);
            Auction deletedAuction = context.Auctions.SingleOrDefault(a => a.Id == auctionId);
            context.Auctions.Remove(deletedAuction);
            context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
