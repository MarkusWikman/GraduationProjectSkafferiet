namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class RecipesVM
    {
        public string Title { get; set; }
        public int MissedIngredientCount { get; set; }        
        public string Image { get; set; }
        public int Id { get; set; }
        public int IngredientsTotally { get; set; }
        public int Multiple { get; set; } = 1;
    }
}
