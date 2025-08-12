using ApiProjeKampi.WebApi.DTO.CategoryDtos;
using ApiProjeKampi.WebApi.DTO.FeatureDtos;
using ApiProjeKampi.WebApi.DTO.MessageDto;
using ApiProjeKampi.WebApi.DTO.NotificationDto;
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
            
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWhitCategoryDto>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z => z.Category.CategoryName)).ReverseMap();

            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
