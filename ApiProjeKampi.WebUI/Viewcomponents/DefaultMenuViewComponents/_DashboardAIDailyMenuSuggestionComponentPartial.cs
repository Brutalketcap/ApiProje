using ApiProjeKampi.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ApiProjeKampi.WebUI.Viewcomponents.DefaultMenuViewComponents
{
    public class _DashboardAIDailyMenuSuggestionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string OpenAIKey = "";
        public _DashboardAIDailyMenuSuggestionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<IViewComponentResult> Invoke()
        {

            var openAiClient = _httpClientFactory.CreateClient();
            openAiClient.BaseAddress = new Uri("https://api.openai.com/");
            openAiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", OpenAIKey);

            string prompt = @"
Aşağıdaki formatta rastgele 4 farklı dünya mutfağından (ör: Çin, İtalyan, Türk, Hint, Japon, Fransız, Meksika...) 
her biri için günlük bir menü oluştur.

Kurallar:
- 4 farklı ülke mutfağı olacak.
- Ülkeleri rastgele seç.
- Her mutfağın içinde 4 yemek olsun (çorba, ana yemek, yan yemek, tatlı gibi).
- Her yemeğe kısa bir açıklama ve fiyat önerisi ekle.
- Cevap sadece geçerli bir JSON olsun, ek açıklama verme.

JSON formatı tam olarak şöyle olsun:

[
  {
    ""Cuisine"": ""Italian"",
    ""MenuTitle"": ""Authentic Italian Daily Menu"",
    ""Items"": [
      { ""Name"": ""Soup Name"", ""Description"": ""..."", ""Price"": 10 },
      { ""Name"": ""Main Dish"", ""Description"": ""..."", ""Price"": 20 },
      { ""Name"": ""Side Dish"", ""Description"": ""..."", ""Price"": 8 },
      { ""Name"": ""Dessert"", ""Description"": ""..."", ""Price"": 7 }
    ]
  }
]
";

            var body = new
            {
                model = "gpt-4.1-mini",   // istersen değiştir
                messages = new[]
                {
                new { role = "system", content = "Sadece JSON üret." },
                new { role = "user", content = prompt }
            }
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await openAiClient.PostAsync("v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();

            dynamic obj = JsonConvert.DeserializeObject(responseJson);
            string aiContent = obj.choices[0].message.content.ToString();

            List<MenuSuggestionDto> menus;

            try
            {
                menus = JsonConvert.DeserializeObject<List<MenuSuggestionDto>>(aiContent);
            }
            catch
            {
                menus = new();
            }

            return View(menus);
        }
    }
}
}
