using ApiProjeKampi.WebUI.Dtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.Viewcomponents.DashboardViewComponents
{
    public class _DashboardWidgetsCompnentsPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _DashboardWidgetsCompnentsPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int r1,r2,r3,r4;
            Random rnd = new Random();
            r1 = rnd.Next(1, 35);
            r2 = rnd.Next(1, 35);
            r3 = rnd.Next(1, 35);
            r4 = rnd.Next(1, 35);

            var client = new HttpClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Reservations/GetTotalReservationCount");
            var jsonaData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonaData;
            ViewBag.r1 = r1;


            var client2 = new HttpClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7041/api/Reservations/GetTotalCustomerCount");
            var jsonaData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 =jsonaData2;
            ViewBag.r2 = r2;

            var client3 = new HttpClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7041/api/Reservations/GetPendingReservations");
            var jsonaData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonaData3;
            ViewBag.r3 = r3;


            var client4 = new HttpClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7041/api/Reservations/GetApprovedReservations");
            var jsonaData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsonaData4;
            ViewBag.r4 = r4;
            return View();

        }
    }
}
