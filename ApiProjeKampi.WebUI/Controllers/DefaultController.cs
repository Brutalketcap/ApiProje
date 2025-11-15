using ApiProjeKampi.WebUI.Dtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Index(CreateReservationDto createReservationDto)
        {
            createReservationDto.ReservationStatus = "Onay Bekliyor";

            var cleint = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(createReservationDto);
            StringContent StringContent= new StringContent(jsonDate, Encoding.UTF8,"application/json");
            var responseMessage = await cleint.PostAsync("https://localhost:7041/api/Reservations", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
