using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.ReservationDto;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {

            return Ok(_context.Reservations.ToList());
        }

        [HttpPost]
        public IActionResult CreatReservation(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Eklme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Silme İşlemi Başarılı");
        }

        [HttpGet("GetReservationId")]
        public IActionResult GetReservationById(int id)
        {
            var value = _context.Reservations.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var value = _context.Reservations.Find(updateReservationDto);
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Güncelleme İşlemi Başarılı");
        }

        [HttpGet("GetTotalReservationCount")]
        public IActionResult GetTotalReservationCount()
        {
            var values = _context.Reservations.Count();
            return Ok(values);

        }
        [HttpGet("GetTotalCustomerCount")]
        public IActionResult GetTotalCustomerCount()
        {
            var values = _context.Reservations.Sum(x => x.CountofPeople);
            return Ok(values);
        }

        [HttpGet("GetPendingReservations")]
        public IActionResult GetPendingReservations()
        {
            var values = _context.Reservations.Where(x => x.ReservationStatus == "Onay Bekliyor").Count();
            return Ok(values);
        }

        [HttpGet("GetApprovedReservations")]
        public IActionResult GetApprovedReservations()
        {
            var values = _context.Reservations.Where(x => x.ReservationStatus == "Onaylandi").Count();
            return Ok(values);
        }

        [HttpGet("GetReservationStats")]
        public IActionResult GetReservationStatus()
        {
            DateTime today = DateTime.Today;
            DateTime fourMonthsAgo = today.AddMonths(-3);

            var rawData = _context.Reservations
                .Where(r => r.ReservationDate >= fourMonthsAgo)
                .GroupBy(r => new { r.ReservationDate.Year, r.ReservationDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Approved = g.Count(x => x.ReservationStatus == "Onaylandı"),
                    Pending = g.Count(x => x.ReservationStatus == "Onay Bekliyor"),
                    Canceled = g.Count(x => x.ReservationStatus == "İptal Edildi")
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList(); // Burada SQL biter, veriler RAM’e alınır

            // 2. Bellekte DTO'ya mapleme + tarih formatlama
            var result = rawData.Select(x => new ReservationChartDto
            {
                Month = new DateTime(x.Year, x.Month, 1).ToString("MMMM yyyy"),
                Approved = x.Approved,
                Pending = x.Pending,
                Canceled = x.Canceled
            }).ToList();

            return Ok(result);

        }



    }
}
