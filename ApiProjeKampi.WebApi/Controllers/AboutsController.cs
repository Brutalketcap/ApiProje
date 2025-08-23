using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.AboutDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AboutsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _context.Abouts.ToList();
            
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _context.Abouts.Add(value);
            _context.SaveChanges();
            return Ok("Hakinda Alani Ekleme İşlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Hakinda Alani Silme işlem Başarılı");
        }

        [HttpGet("GetAboutById")]
        public IActionResult GetAboutById(int id)
        {
            var value = _context.Abouts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateAbout(GetAboutByIdDto getAboutByIdDto) 
        {
            var value = _mapper.Map<About>(getAboutByIdDto);
            _context.Abouts.Update(value);
            _context.SaveChanges();
            return Ok("Hakinda Alani Güncellem İşlemi Başarılı"); 
        }
    }
}
