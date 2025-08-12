using ApiProjeKampi.WebUI.Dtos.MessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessaage = await client.GetAsync("https://localhost:7041/api/Messages/MessageListByReadFalse");
            if (responseMessaage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessaage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByReadFalseDto>>(jsonDate);

                return View(values);
            }

            return View();
        }

    }
}
