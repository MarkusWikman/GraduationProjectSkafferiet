namespace GraduationProjectSkafferiet.Models
{
    public class RecipeInfoDto
    {

        // TODO: Ett tappert försök till att hämta api
        public string Name { get; set; }
        public List<StepsDto> Steps{ get; set; }
        public class StepsDto
        {
            public List<IngredientDto> Ingredients{ get; set; }
            public string Step { get; set; }

            public class IngredientDto
            {
                public string Name { get; set; }
            }
        }

    }
}
