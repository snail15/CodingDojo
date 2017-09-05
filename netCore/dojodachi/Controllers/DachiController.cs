using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
    public class DachiController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            if(HttpContext.Session.GetObjectFromJson<Dachi>("Dachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("Dachi", new Dachi());
            }
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            ViewBag.Fullness = dachi.fullness;
            ViewBag.Happiness = dachi.happiness;
            ViewBag.Meal = dachi.meal;
            ViewBag.Energy = dachi.energy;
            return View();
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed() {
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            int gain = dachi.Feed();
            bool win = dachi.CheckWin();
            bool lose = dachi.CheckLose();
            var result = new {
                meal = dachi.meal,
                fullness = dachi.fullness,
                win = win,
                lose = lose,
                gain = gain
            };
            HttpContext.Session.SetObjectAsJson("Dachi", dachi);
            return Json(result);
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play(){
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            int gain = dachi.Play();
            bool win = dachi.CheckWin();
            bool lose = dachi.CheckLose();
            var result = new {
                energy = dachi.energy,
                happiness = dachi.happiness,
                win = win,
                lose = lose,
                gain = gain
            };
            HttpContext.Session.SetObjectAsJson("Dachi", dachi);
            return Json(result);
        }
        [HttpGet]
        [Route("work")]
        public IActionResult Work(){
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            int gain = dachi.Work();
            bool win = dachi.CheckWin();
            bool lose = dachi.CheckLose();
            var result = new {
                energy = dachi.energy,
                meal = dachi.meal,
                win = win,
                lose = lose,
                gain = gain
            };
            HttpContext.Session.SetObjectAsJson("Dachi", dachi);
            return Json(result);
        }
        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep(){
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            int gain = dachi.Sleep();
            bool win = dachi.CheckWin();
            bool lose = dachi.CheckLose();
            var result = new {
                energy = dachi.energy,
                fullness = dachi.fullness,
                happiness = dachi.happiness,
                win = win,
                lose = lose,
                gain = gain
            };
            HttpContext.Session.SetObjectAsJson("Dachi", dachi);
            return Json(result);
        }


    }
        public static class SessionExtensions {
            public static void SetObjectAsJson(this ISession session, string key, object value) {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
            public static T GetObjectFromJson<T>(this ISession session, string key) {
                var value = session.GetString(key);
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
}