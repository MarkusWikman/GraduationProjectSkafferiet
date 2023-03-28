using Microsoft.AspNetCore.Identity;

namespace GraduationProjectSkafferiet.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public  List<Ingredient> Inventory { get; set; }
    }
}
