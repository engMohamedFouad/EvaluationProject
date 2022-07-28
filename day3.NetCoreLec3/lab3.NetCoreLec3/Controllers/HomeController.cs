using lab3.NetCoreLec3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab3.NetCoreLec3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string item)
        {
            //to return String
            // return Content("wellcome in Asp.Net Core");

            //to return status as string also
            //return Ok();

            //to return simulate  notfound page 404 not found
            //return NotFound();


            //to redirct to action
            //return RedirectToAction("show");


            //to return to remote website or page
            // return Redirect("http://www.facebook.com");


            //بيفتح الصفحة اللي هيتوجه ليها بعد اول مره مباشرتآ
            //indexمش هيروح بعد اول مرة لل
            //return RedirectPermanent("http://www.facebook.com");


            //return 400 page not work right
            //if (item == null) return BadRequest();
            //var newItem = new { id=1,name="mohamed"}; // create the object anonymious at run time to return values
            //if (newItem != null) return Ok(newItem); //return ok if not null
            //else return NotFound(); 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}