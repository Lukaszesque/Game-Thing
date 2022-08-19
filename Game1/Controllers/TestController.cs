using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Game1.Controllers
{
    public class TestController : Controller
    {
        //GET: /Test/
        public IActionResult Index()
        {
            return View();
        }

        //GET: /Test/Welcome
        public IActionResult Welcome(string name, int numTimes = 1) 
            { 
                ViewData["Message"] = "Hello" + name;
                ViewData["NumTimes"] = numTimes;

                return View();
            }
    }
}
