using ApiProjeKampi.WebUI.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _DefaultContactComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cleint = _httpClientFactory.CreateClient();
            var responseMessage = await cleint.GetAsync("https://localhost:7041/api/Contacts");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonDate= await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonDate);
                return View(value);
            }

            return View();
        }
    }
}
