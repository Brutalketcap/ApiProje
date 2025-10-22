
using ApiProjeKampi.WebUI.Dtos.WyChooseYummyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class WhyChooseYummyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhyChooseYummyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WhyChooseList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyChooseYummyDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateWhyChoose()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhyChoose(CreateWhyChooseYummyDto createWhyChooseYummyDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWhyChooseYummyDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7041/api/Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyChooseList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWhyChoose(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7041/api/Services?id=" + id);
            return RedirectToAction("WhyChooseList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWhyChoose(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Services/GetService?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetWhyChooseYummyByIdDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWhyChoose(UpdateWhyChooseYummyDto updateWhyChooseYummyDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWhyChooseYummyDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7041/api/Services", stringContent);
            return RedirectToAction("WhyChooseList");

        }

    }
}


