using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var value = _context.Services.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateService(Service servce)
        {
            _context.Services.Add(servce);
            _context.SaveChanges();
            return Ok("Hizmet ekleme işlemi başarılı");


        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet Silme işlemi başarılı");
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();

            return Ok("Hizmet güncellme işlemi Başarılı");
        }
    }
}
