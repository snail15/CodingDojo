using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace movieapi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector dbConnector;

        public YourController(DbConnector connect)
        {
            dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View();
        }
    }
}
