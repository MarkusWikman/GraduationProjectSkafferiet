using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace GraduationProjectSkafferiet.Models
{
    public class UserInventory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Ingredient> Inventory { get; set; } = new List<Ingredient>();

        public class Ingredient
        {
            [Key]
            public int Id { get; set; }
            public string IngredientName { get; set; } = null!;
        }
    }
}
