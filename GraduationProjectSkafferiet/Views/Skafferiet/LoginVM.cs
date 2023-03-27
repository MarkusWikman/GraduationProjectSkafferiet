using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        [Display(Prompt = "Password")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
    }
}
