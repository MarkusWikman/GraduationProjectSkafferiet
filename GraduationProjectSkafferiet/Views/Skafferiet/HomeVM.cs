using GraduationProjectSkafferiet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class HomeVM
    {
        public SelectListItem[] IngredientsList { get; set; }
        public Ingredient[] Inventory { get; set; }

        public string AddIngredient { get; set; }
    }
}
