using ApiProjeKampi.WebUI.Dtos.ImagesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class GallaryController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public GallaryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ImageList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Images");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonsData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonsData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDto createImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7041/api/Images", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ImageList");
            }
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7041/api/Images/GetImageById?id=" + id);

            return RedirectToAction("ImageList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateImage(int id)
        { 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Images/GetImageById?id="+id);
            var jsonsData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetImageByIdDto>(jsonsData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateImageDto updateImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7041/api/Images",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ImageList");
            }
            return View();

        }

    }
}
