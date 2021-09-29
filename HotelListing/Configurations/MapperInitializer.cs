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
            CreateMap<Country, CreateCountryDTO>();
            CreateMap<Country, CountryDTO>();

            CreateMap<Hotel, CreateHotelDTO>();
            CreateMap<Hotel, HotelDTO>();

        }
    }
}
