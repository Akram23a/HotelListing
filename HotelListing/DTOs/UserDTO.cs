using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.DTOs
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Password Limited between {2} and {1}", MinimumLength = 8)]
        public string Password { get; set; }

    }
    public class UserDTO : LoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }


    }
}
