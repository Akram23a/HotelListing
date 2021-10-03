using System;
using HotelListing.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Data
{
    public class APIUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static implicit operator APIUser(UserDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
