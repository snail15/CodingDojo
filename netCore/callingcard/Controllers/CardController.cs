using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingcard.Controllers
{
    public class CardController : Controller {
        [HttpGet]
        [Route("{first}/{last}/{age}/{favColor}")]
        public JsonResult DisplayPerson(string first, string last, int age, string favColor) {
            var Person = new {  FirstName = first,
                                LastName = last,
                                Age = age,
                                FavoriteColor = favColor};
            return Json(Person);
        }
    }
}