using GraduationProjectSkafferiet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class HomeVM
    {
        public SelectListItem[] IngredientsList { get; set; }
        public SelectListItem[] Inventory { get; set; }

        public string[] SelectedIngredients { get; set; }

        public string AddIngredient { get; set; }

        public bool IsIngredientChosen { get; set; }

        public string Name { get; set; }
        public bool IsAllChosen { get; set; }

    }
}
