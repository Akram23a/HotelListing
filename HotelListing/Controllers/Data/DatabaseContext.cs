﻿using System;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Controllers.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
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
            builder.Entity<Hotel>().HasData(
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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}