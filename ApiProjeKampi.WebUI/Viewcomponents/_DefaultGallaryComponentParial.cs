using ApiProjeKampi.WebUI.Dtos.ImagesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _DefaultGallaryComponentParial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultGallaryComponentParial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Images");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonDate);
                return View(values);
            }
            return View();
        }

    }
}
