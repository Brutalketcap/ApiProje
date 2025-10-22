using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents.HomePageViewComponents
{
    public class _HomePageStatisticsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7041/api/Statistics/ProductCount");
            var value1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = value1;

            var responseMessage2 = await client.GetAsync("https://localhost:7041/api/Statistics/ReservationCount");
            var value2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = value2;
            
            var responseMessage3 = await client.GetAsync("https://localhost:7041/api/Statistics/ChefCount");
            var value3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = value3;
            
            var responseMessage4 = await client.GetAsync("https://localhost:7041/api/Statistics/TotalGuestnCount");
            var value4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = value4;

            return View();
        }
    }
}
