using GraduationProjectSkafferiet.Views.Skafferiet;

namespace GraduationProjectSkafferiet.Models
{
    public class DataService
    {
        IHttpClientFactory clientFactory;
        public DataService(IHttpClientFactory clientFactory) // Kräver följande i program: builder.Services.AddHttpClient();
        {
            this.clientFactory = clientFactory;
        }
        public async Task<RecipesVM[]> GetRecipes()
        {
            const string API_KEY = "9fc1e7bd34df46aa8a7b9f09e0ca5f4e";

            // TODO: Add a foreach to make a string of items

            var url = $"https://api.spoonacular.com/recipes/findByIngredients?ingredients=apples,+flour,+sugar&number=5&apiKey={API_KEY}";
            // Hämta en instans av HttpClient för att göra anrop med
            HttpClient httpClient = clientFactory.CreateClient();
            // Anropa Web-API:t och deserialisera resultatet till en array av DTO-klasser
            RecipeDto[] recipes = await httpClient.GetFromJsonAsync<RecipeDto[]>(url);
            // Konvertera DTO-klasserna till vy-modeller
            return recipes
            .Select(o => new RecipesVM
            {
                Title = o.Title,
                Id = o.Id,
                MissedIngredientCount = o.MissedIngredientCount,
                IngredientsTotally = o.UsedIngredientCount + o.MissedIngredientCount,
                Image = o.Image,
            })
            .ToArray();
        }
    }
}
