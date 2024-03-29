﻿using GraduationProjectSkafferiet.Models;
using GraduationProjectSkafferiet.Views.Skafferiet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace GraduationProjectSkafferiet.Controllers
{
    public class SkafferietController : Controller
    {
        DataService dataService;
        AccountService accountService;
        UserManager<ApplicationUser> userManager;
        public SkafferietController(DataService dataService, AccountService accountService, UserManager<ApplicationUser> userManager)
        {
            this.dataService = dataService;
            this.accountService = accountService;
            this.userManager = userManager;
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

        [Authorize]
        [HttpGet("Home")]
        public async Task<IActionResult> Home()
        {
            var model = await dataService.GetIngredientsAndInventoryAsync();
            model.IsIngredientChosen = model.Inventory.Length == 0 ? false : true;
            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = userManager.FindByIdAsync(userId).Result;
            model.Name = user.FirstName;
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
        //[HttpGet("/ChangeCheckedTrue")]
        //public IActionResult ChangeCheckedTrue()
        //{
        //    return RedirectToAction(nameof(Home), );
        //}
        //[HttpGet("/ChangeCheckedFalse")]
        //public IActionResult ChangeCheckedFalse()
        //{
        //    return RedirectToAction(nameof(Home), model);
        //}


        [Authorize]
        [HttpGet("/Recipes")]
        public IActionResult Recipes(RecipesVM[] model)
        {
            return View(model);
        }

        [Authorize]
        [HttpPost("/Recipes")]
		public async Task<IActionResult> Recipes(HomeVM model)
		{
            var recipeModel = await dataService.GetRecipes(model.SelectedIngredients);
            return View(recipeModel);
            //return RedirectToAction(nameof(Recipes), recipeModel);
		}

        [Authorize]
        [HttpGet("/recipe")]
        public async Task<IActionResult> RecipeInfo(int id)
        {
            RecipeInfoVM vm = await dataService.GetRecipeByIdAsync(id);
            return View(vm);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(string ingredientName)
        {
            await dataService.DeleteIngredientAsync(ingredientName);
            return RedirectToAction(nameof(Index));
        }

    }
}
