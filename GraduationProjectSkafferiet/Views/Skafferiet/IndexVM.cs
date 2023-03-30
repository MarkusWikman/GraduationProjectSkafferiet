using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class IndexVM
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name", Prompt = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name", Prompt = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email Adress", Prompt = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]        
        [Display(Prompt = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password", Prompt = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
