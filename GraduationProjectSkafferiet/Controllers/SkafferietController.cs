using GraduationProjectSkafferiet.Models;
using GraduationProjectSkafferiet.Views.Skafferiet;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectSkafferiet.Controllers
{
    public class SkafferietController : Controller
    {
        DataService dataService;
        AccountService accountService;
        public SkafferietController(DataService dataService, AccountService accountService)
        {
            this.dataService = dataService;
            this.accountService = accountService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("")]
        public async Task<IActionResult> IndexAsync(IndexVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            // Try to register user
            var errorMessage = await accountService.TryRegisterAsync(viewModel);
            if (errorMessage != null)
            {
                // Show error
                ModelState.AddModelError(string.Empty, errorMessage);
                return View();
            }
            // Redirect user
            return RedirectToAction(nameof(Login));
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> LoginAsync(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            // Check if credentials is valid (and set auth cookie)
            var errorMessage = await accountService.TryLoginAsync(viewModel);
            if (errorMessage != null)
            {
                // Show error
                ModelState.AddModelError(string.Empty, errorMessage);
                return View();
            }
            // Redirect user
            return RedirectToAction(nameof(Index));
        }

    }
}
