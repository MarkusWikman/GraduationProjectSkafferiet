using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class HomeVM
    {
        public SelectListItem[] IngredientsList { get; set; }
        public List<string> Inventory { get; set; }

        public string AddIngredient { get; set; }
    }
}
