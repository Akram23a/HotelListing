using System;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Data
{
    public class APIUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
