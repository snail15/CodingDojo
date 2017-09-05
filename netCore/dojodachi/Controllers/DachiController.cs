using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace dojodachi.Controllers
{
    public class DachiController : Controller
    {
        public Dachi dachi = new Dachi();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Fullness = dachi.fullness;
            ViewBag.Happiness = dachi.happiness;
            ViewBag.Meal = dachi.meal;
            ViewBag.Energy = dachi.energy;
            return View();
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed() {
            bool win = dachi.CheckWin();
            if (!win){
                return RedirectToAction("Lose");
            }
            bool lose = dachi.CheckLose();
            dachi.Feed();
            var result = new {
                meal = dachi.meal,
                fullness = dachi.fullness
            };
            return Json(result);
        }

        [HttpGet]
        [Route("lose")]
        public IActionResult Lose(){
            return View();
        }

    }
}