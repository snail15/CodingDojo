using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace randompasscode.Controllers
{
    public class PasswordController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("Attempt", 0);
            ViewBag.Password = GeneratePassword(14);
            ViewBag.Attempt = HttpContext.Session.GetInt32("Attempt");
            return View();
        }
        [HttpGet]
        [Route("generate")]
        public JsonResult Generate(){
            string newPassword = GeneratePassword(14);
            var password = new { password = newPassword,
                                attempt = HttpContext.Session.GetInt32("Attempt")};
            return Json(password);
        }

        private string GeneratePassword(int length){
            int? currnetAttempt = HttpContext.Session.GetInt32("Attempt");
            HttpContext.Session.SetInt32("Attempt", (int)currnetAttempt + 1);
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            int password = 1;
            while(password <= 14)
            {
                char c = (char)random.Next(0, 129);
                if(c != ' '){
                    builder.Append(c);
                    password++;
                }
            }
            return builder.ToString();
        }
    }
}