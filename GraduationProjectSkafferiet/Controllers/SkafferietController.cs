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
    }
}
