using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.ReservationDto;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var value= _context.Reservations.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto) 
        {
            var value= _context.Reservations.Find(updateReservationDto);
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Güncelleme İşlemi Başarılı");
        }

    }
}
















