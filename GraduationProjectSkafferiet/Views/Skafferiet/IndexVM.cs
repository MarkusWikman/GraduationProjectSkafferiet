using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class IndexVM
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Prompt = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Prompt = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Prompt = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]        
        [Display(Prompt = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Prompt = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
