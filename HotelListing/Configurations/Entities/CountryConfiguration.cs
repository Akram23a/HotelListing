using System;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "France",
                    Abreveation = "FRA"
                },
                new Country
                {
                    Id = 2,
                    Name = "England",
                    Abreveation = "ENG"
                },
                new Country
                {
                    Id = 3,
                    Name = "Spain",
                    Abreveation = "SPA"
                }
                );
        }
    }
}
