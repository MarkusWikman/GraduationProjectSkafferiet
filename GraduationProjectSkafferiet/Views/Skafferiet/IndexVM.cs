using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class IndexVM
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name  = "First name", Prompt = "First name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last name", Prompt = "Last name")]
        public string LastName { get; set; }


        [Display(Name = "Email address", Prompt = "Email adress")]
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Password", Prompt = "Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm password")]
        [Required(ErrorMessage = "This field is required")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
