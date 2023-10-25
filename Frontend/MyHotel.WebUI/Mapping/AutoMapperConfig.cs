using AutoMapper;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.ServiceDto;

namespace MyHotel.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ListServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<AddServiceDto, Service>().ReverseMap();
        }
    }
}
