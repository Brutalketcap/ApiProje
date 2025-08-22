using ApiProjeKampi.WebUI.Dtos.CategoryDtos;
using ApiProjeKampi.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<IActionResult> ProductList()
        {
            var clinet = _httpClientFactory.CreateClient();
            var responseMessage = await clinet.GetAsync("https://localhost:7041/api/Products/ProductWhitCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var vaules = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonDate);
                return View(vaules);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Categories");

            var jsonDate = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDate);
            List<SelectListItem> CategoryValues = (from x in values
                                            select new SelectListItem
                                            {
                                                Text= x.CategoryName,
                                                Value= x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = CategoryValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7041/api/Products/CreateProductWithCategory", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                //SerializeObject ve DeserializeObject ne olduğunu ve StringContent "application/json RedirectToAction bak


                return RedirectToAction("ProductList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCatory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7041/api/Products?id=" + id); /////////////////////////////////////////////

            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7041/api/Products/GetProducts?id=" + id);
            var jsonDate = await responseMassage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetProductByIdDto>(jsonDate);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "aplication/json");
            await client.PutAsync("https://localhost:7041/api/Products", stringContent);
            return RedirectToAction("ProductList");
        }


    }
}
