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
            var url = "https://jsonplaceholder.typicode.com/photos";
            // Hämta en instans av HttpClient för att göra anrop med
            HttpClient httpClient = clientFactory.CreateClient();
            // Anropa Web-API:t och deserialisera resultatet till en array av DTO-klasser
            RecipesVM[] photos = await httpClient.GetFromJsonAsync<PhotoDto[]>(url);
            // Konvertera DTO-klasserna till vy-modeller
            return photos
            .Select(o => new IndexVM
            {
                Title = o.Title,
                ImgUrl = o.Url
            })
            .ToArray();
        }
    }
}
