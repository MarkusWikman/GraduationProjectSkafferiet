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
            model.Inventory = new List<string>() {"Apple", "Milk" };

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
            //RecipeInfoVM vm = await dataService.GetRecipeByIdAsync(id);
            RecipeInfoVM vm = new RecipeInfoVM()
            {
                Title = "Pasta Carbonara",
                Ingredients = { "Pasta", "Bacon", "Ägg", "Garlic", "Parmesan", "Peccorino"},
                Instructions = { "Stek bacon", "Koka pasta", "Servera med parmesan"},
                Image = "data:image/jpeg;base64,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"
            };
            return View(vm);
        }

        
    }
}
