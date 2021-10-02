using System;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public HotelConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Le Francisco",
                    Address = "12 rue de test, 78000 Versailles",
                    Rating = 4.3,
                    CountryId = 1

                },
                new Hotel
                {
                    Id = 2,
                    Name = "The EnglishOne",
                    Address = "19 Spooner St, 12000 London",
                    Rating = 3.3,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "El Espanol",
                    Address = "45 placa cataluna, 08073 Barcelona",
                    Rating = 4.7,
                    CountryId = 3
                }
                );
        }
    }
}
