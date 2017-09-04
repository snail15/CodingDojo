using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace dojosurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("show")]
        public IActionResult Show(string name, string location, string favlang, string comment){
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Favlang = favlang;
            ViewBag.Comment = comment;
            return View();
        }
    }
}