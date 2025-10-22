using ApiProjeKampi.WebUI.Dtos.FeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FeatureDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7041/api/Features");
            if (responseMassage.IsSuccessStatusCode)
            {
                var value = await responseMassage.Content.ReadAsStringAsync();
                var jsonDate = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(value);
                return View(jsonDate);

            }
            return View();
        }
    }
}
