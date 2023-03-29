using GraduationProjectSkafferiet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class HomeVM
    {
        public SelectListItem[] IngredientsList { get; set; }
        public SelectListItem[] Inventory { get; set; }

        public string[] SelectedIngredients { get; set; }

        public string AddIngredient { get; set; }
    }
}
