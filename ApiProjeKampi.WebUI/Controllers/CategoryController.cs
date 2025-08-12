using ApiProjeKampi.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<IActionResult> CategoryList()
        {
            var clinet = _httpClientFactory.CreateClient();
            var responseMessage = await clinet.GetAsync("https://localhost:7041/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var vaules = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDate);
                return View(vaules);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7041/api/Categories", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                //SerializeObject ve DeserializeObject ne olduğunu ve StringContent "application/json RedirectToAction bak


                return RedirectToAction("CategoryList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCatory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7041/api/Categories?id=" + id); /////////////////////////////////////////////

            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCatory(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7041/api/Categories/GetCategory?id=" + id);
            var jsonDate =  await responseMassage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetCategoryByIdDto>(jsonDate);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCatory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate= JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8,"aplication/json" );
            await client.PutAsync("https://localhost:7041/api/Categories", stringContent);
            return RedirectToAction("CategoryList");
        }
    }
}
