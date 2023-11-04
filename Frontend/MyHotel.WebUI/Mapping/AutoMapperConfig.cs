using AutoMapper;
using MyHotel.DtoLayer.DTOs.RoomDto;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.AboutDto;
using MyHotel.WebUI.DTOs.LoginDto;
using MyHotel.WebUI.DTOs.RegisterDto;
using MyHotel.WebUI.DTOs.BookingDto;
using MyHotel.WebUI.DTOs.RoomDto;
using MyHotel.WebUI.DTOs.ServiceDto;
using MyHotel.WebUI.DTOs.StaffDto;
using MyHotel.WebUI.DTOs.SubscribeDto;
using MyHotel.WebUI.DTOs.TestimonialDto;

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

            CreateMap<ListRoomDto,Room>().ReverseMap();

            CreateMap<ListTestimonialDto,Testimonial>().ReverseMap();
            
            CreateMap<ListStaffDto,Staff>().ReverseMap();

            CreateMap<AddSubscriberDto, Subscribe>().ReverseMap();

            CreateMap<AddBookingDto,Booking>().ReverseMap();
        }
    }
}
