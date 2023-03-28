using GraduationProjectSkafferiet.Models;
using GraduationProjectSkafferiet.Views.Skafferiet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if (User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(Home));
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
            return RedirectToAction(nameof(Home));
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(Home));
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
            return RedirectToAction(nameof(Home));
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            accountService.SignOut();
            return RedirectToAction(nameof(Login));
        }

        //[Authorize]
        [HttpGet("/Home")]
        public IActionResult Home(HomeVM model)
        {
            model.IngredientsList = dataService.GetIngredientList();
            model.Inventory = new List<string>() { "Apple", "Milk" };

            return View(model);
        }

        [HttpPost("/Home")]
        public async Task<IActionResult> CreateAsync(HomeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await dataService.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }


        //[Authorize]
        [HttpGet("/Recipes")]
        public async Task<IActionResult> RecipesAsync()
        {
            var model = await dataService.GetRecipes();
            return View(model);
        }

        //[Authorize]
        [HttpGet("/recipe")]
        public async Task<IActionResult> RecipeInfo(int id)
        {
            RecipeInfoVM vm = await dataService.GetRecipeByIdAsync(id);
            
            return View(vm);
        }

        
    }
}
