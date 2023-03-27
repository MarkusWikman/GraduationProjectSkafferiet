using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class RegisterVM
    {
        [Required]
        [Display(Prompt = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Prompt = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Prompt = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]        
        [Display(Prompt = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Prompt = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
