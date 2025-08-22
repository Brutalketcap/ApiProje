using ApiProjeKampi.WebUI.Dtos.FeatureDto;
using ApiProjeKampi.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> FeatureList()
        {
            var clinet = _httpClientFactory.CreateClient();
            var responseMessage = await clinet.GetAsync("https://localhost:7041/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonDate);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondate = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsondate, Encoding.UTF8, "application/json");
            var responseMassage = await client.PostAsync("https://localhost:7041/api/Features", stringContent);
            if (responseMassage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList"); 
            }
            return View();
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7041/api/Features?id=" + id); 

            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7041/api/Features/GetFeature?id=" + id);
            var jsonDate = await responseMassage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetProductByIdDto>(jsonDate);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "aplication/json");
            await client.PutAsync("https://localhost:7041/api/Features", stringContent);
            return RedirectToAction("ProductList");
        }
    }
}
