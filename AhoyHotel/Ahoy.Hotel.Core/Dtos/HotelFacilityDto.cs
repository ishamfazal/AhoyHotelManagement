using Ahoy.Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahoy.Hotel.Core.Dtos
{
    public class HotelFacilityDto
    {
        public HotelDto Hotel { get; set; }
        public FacilityDto Facility { get; set; }
    }
}
