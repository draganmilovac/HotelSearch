using AutoMapper;
using HotelData.Models;

namespace HotelApplication.Dtos.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelDto, Hotel>().ReverseMap();
            CreateMap<SortedHotelsDto, Hotel>().ReverseMap();
        }
    }
}
