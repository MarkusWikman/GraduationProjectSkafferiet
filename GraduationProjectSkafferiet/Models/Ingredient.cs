using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Models
{
    
        public class Ingredient
        {
            
            public int Id { get; set; }
            public string IngredientName { get; set; } = null!;
            public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
    }
