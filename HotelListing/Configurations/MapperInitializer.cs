using System;
using AutoMapper;
using HotelListing.Controllers.Data;
using HotelListing.DTOs;

namespace HotelListing.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();

            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();

        }
    }
}
