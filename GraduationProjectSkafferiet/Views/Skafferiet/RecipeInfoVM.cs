namespace GraduationProjectSkafferiet.Views.Skafferiet
{
    public class RecipeInfoVM
    {
        public string Title { get; set; }
        public List<string> Ingredients{ get; set; } = new List<string>();
        public List<string> Instructions { get; set; } = new List<string>();

        public string Image{ get; set; }
    }
}
