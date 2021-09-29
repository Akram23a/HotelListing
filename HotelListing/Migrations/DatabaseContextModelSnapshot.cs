﻿// <auto-generated />
using HotelListing.Controllers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelListing.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelListing.Controllers.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreveation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abreveation = "FRA",
                            Name = "France"
                        },
                        new
                        {
                            Id = 2,
                            Abreveation = "ENG",
                            Name = "England"
                        },
                        new
                        {
                            Id = 3,
                            Abreveation = "SPA",
                            Name = "Spain"
                        });
                });

            modelBuilder.Entity("HotelListing.Controllers.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "12 rue de test, 78000 Versailles",
                            CountryId = 1,
                            Name = "Le Francisco",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 2,
                            Address = "19 Spooner St, 12000 London",
                            CountryId = 2,
                            Name = "The EnglishOne",
                            Rating = 3.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Address = "45 placa cataluna, 08073 Barcelona",
                            CountryId = 3,
                            Name = "El Espanol",
                            Rating = 4.7000000000000002
                        });
                });

            modelBuilder.Entity("HotelListing.Controllers.Data.Hotel", b =>
                {
                    b.HasOne("HotelListing.Controllers.Data.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}