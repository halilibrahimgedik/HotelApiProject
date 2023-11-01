using AutoMapper;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.AboutDto;
using MyHotel.WebUI.DTOs.LoginDto;
using MyHotel.WebUI.DTOs.RegisterDto;
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

            CreateMap<AddNewUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();

            CreateMap<ListAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();
        }
    }
}
