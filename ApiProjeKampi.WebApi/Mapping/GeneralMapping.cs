using ApiProjeKampi.WebApi.DTO.FeatureDtos;
using ApiProjeKampi.WebApi.DTO.MessageDto;
using ApiProjeKampi.WebApi.DTO.ProductDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;

namespace ApiProjeKampi.WebApi.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            
            CreateMap<Message, CreateFeatureDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWhitCategoryDto>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
        }
    }
}
