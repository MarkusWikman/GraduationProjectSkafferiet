namespace GraduationProjectSkafferiet.Models
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

        public Nutrition Nutrition { get; set; } = new Nutrition();


    }
    public class ExtendedIngredient
    {
        public string Original { get; set; }
    }

    public class Nutrition
    {
        public List<Nutrient> Nutrients { get; set; } = new List<Nutrient> { };

    }

    public class Nutrient {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }

}
