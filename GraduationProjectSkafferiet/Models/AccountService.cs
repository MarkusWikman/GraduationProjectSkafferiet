using GraduationProjectSkafferiet.Views.Skafferiet;
using Microsoft.AspNetCore.Identity;

namespace GraduationProjectSkafferiet.Models
{
    public class AccountService
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<string> TryRegisterAsync(IndexVM viewModel)
        {
            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
            };

            IdentityResult result = await
                userManager.CreateAsync(user, viewModel.Password);

            return result.Errors.FirstOrDefault()?.Description;
        }
        public async Task<string> TryLoginAsync(LoginVM viewModel)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(
                viewModel.Email,
                viewModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);
            if (result.Succeeded)
                return null;
            else
                return "login failed";
        }
        internal void SignOut()
        {
            var result = signInManager.SignOutAsync();
        }
    }
}
