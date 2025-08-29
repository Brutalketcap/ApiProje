using ApiProjeKampi.WebUI.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactList()
        {
            var clinet = _httpClientFactory.CreateClient();
            var responseMessage = await clinet.GetAsync("https://localhost:7041/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonDate);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreatContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7041/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7041/api/Contacts?id=" + id);
        
            return RedirectToAction("ContactList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7041/api/Contacts/GetContact?id=" + id);
            var jsonDate = await responseMassage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetContactByIdDto>(jsonDate);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(updateContactDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7041/api/Contacts", stringContent);
            return RedirectToAction("ContactList");
        }


    }

}
