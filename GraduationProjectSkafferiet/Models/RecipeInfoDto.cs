﻿namespace GraduationProjectSkafferiet.Models
{
    public class RecipeInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public string? Instructions { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }


    }
    public class ExtendedIngredient
    {
        public string Original { get; set; }
    }
}
