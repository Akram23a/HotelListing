using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.DTOs
{
   

    public class CreateCountryDTO
    {


        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Country Abreveation is too long")]

        public string Abreveation { get; set; }

    }

    public class CountryDTO : CreateHotelDTO
    {

        public int Id { get; set; }
        public virtual IList<HotelDTO> Hotels { get; set; }


    }
}
