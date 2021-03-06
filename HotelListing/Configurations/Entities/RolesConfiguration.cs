using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public RolesConfiguration() 
        {

        }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
                );
        }
    }
}
