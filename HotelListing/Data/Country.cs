using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelListing.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abreveation { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}
