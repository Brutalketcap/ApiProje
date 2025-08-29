using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.ImagesDto;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ImagesList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult ImageCreate(CreateImageDto createImagesDto)
        {
            var values = _mapper.Map<Image>(createImagesDto);
            _context.Images.Add(values);
            _context.SaveChanges();
            return Ok("Resim Eklem Işlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult ImageDelete(int id)
        {
            var values = _context.Images.Find(id);
            _context.Images.Remove(values);
            _context.SaveChanges();
            return Ok("Resim Silme İşlemi Başarılı");
        }

        [HttpGet("GetImageById")]
        public IActionResult GetImageById(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult ImageUpdate(GetImageByIdDto getImageByIdDto) 
        {
            var value = _mapper.Map<Image>(getImageByIdDto);
            _context.Images.Update(value);
            _context.SaveChanges();

            return Ok("Resmi güncellme İşlmeli Başarılı");
        }



    }
}
