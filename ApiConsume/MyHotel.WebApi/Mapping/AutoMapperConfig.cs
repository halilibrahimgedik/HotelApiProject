using AutoMapper;
using MyHotel.DtoLayer.DTOs.RoomDto;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddRoomDto, Room>();
            CreateMap<Room, AddRoomDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
