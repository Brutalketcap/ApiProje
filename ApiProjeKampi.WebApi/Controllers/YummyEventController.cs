using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventController : ControllerBase
    {
        private readonly ApiContext _context;

        public YummyEventController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var value = _context.YummyEvents.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateService(YummyEvent yummyEvet)
        {
            _context.YummyEvents.Add(yummyEvet);
            _context.SaveChanges();
            return Ok("Etkinlik ekleme işlemi başarılı");


        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.YummyEvents.Find(id); 
            _context.YummyEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Etkinlik Silme işlemi başarılı");
        }

        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateService(YummyEvent yummyEvet )
        {
            _context.YummyEvents.Update(yummyEvet);
            _context.SaveChanges();

            return Ok("Etkinlik güncellme işlemi Başarılı");
        }

    }
}
