using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.FeatureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeaturesList()
        {
            var values = _context.Features.ToList();

            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme işlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _context.Features.Find(id);
            _context.Features.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetByFeature(int id)
        {
            var values = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(values));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(values);
            _context.SaveChanges();

            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
