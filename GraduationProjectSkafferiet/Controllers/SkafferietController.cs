using GraduationProjectSkafferiet.Views.Skafferiet;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectSkafferiet.Controllers
{
    public class SkafferietController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/login")] 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
            return View();
            }



        }

    }
}
