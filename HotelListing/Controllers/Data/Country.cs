﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Controllers.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abreveation { get; set; }

    }
}