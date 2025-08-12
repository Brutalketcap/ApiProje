using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.NotificationDto;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public NotificationController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();

            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var values = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme işlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var values = _context.Notifications.Find(id);
            _context.Notifications.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetNotification")]
        public IActionResult GetByNotification(int id)
        {
            var values = _context.Notifications.Find(id);
            return Ok(_mapper.Map<GetNotificationByIdDto>(values));
        }
       

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var values = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(values);
            _context.SaveChanges();

            return Ok("Güncelleme İşlemi Başarılı");
        }

    }
}
