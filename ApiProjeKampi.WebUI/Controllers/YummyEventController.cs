using ApiProjeKampi.WebUI.Dtos.YummyEventDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class YummyEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public YummyEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<IActionResult> YummyEventList()
        {
            var clinet = _httpClientFactory.CreateClient();
            var responseMessage = await clinet.GetAsync("https://localhost:7041/api/YummyEvent");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultYummyEventDto>>(jsonDate);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateYummyEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateYummyEvent(CreateYummeyEventDto creatYummeyEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(creatYummeyEventDto);
            StringContent StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7041/api/YummyEvent", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("YummyEventList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7041/api/YummyEvent?id=" + id); 

            return RedirectToAction("YummyEventList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMassage = await client.GetAsync("https://localhost:7041/api/YummyEvent/GetYummyEvent?id=" + id);
            var jsonDate = await responseMassage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetYummyEventGetByIdDto>(jsonDate);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateYummyEvent(UpdateYummyEventDto updateYummyEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(updateYummyEventDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7041/api/YummyEvent", stringContent);
            return RedirectToAction("YummyEventList");
        }

    }
}
