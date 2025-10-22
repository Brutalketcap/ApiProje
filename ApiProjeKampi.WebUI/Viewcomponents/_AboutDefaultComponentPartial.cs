using ApiProjeKampi.WebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7041/api/Abouts");
            if (responseMassage.IsSuccessStatusCode)
            {
                var values = await responseMassage.Content.ReadAsStringAsync();
                var jsonDate = JsonConvert.DeserializeObject<List<ResultAboutDto>>(values);
                return View(jsonDate);
            }
            return View();
        }
    }

}
