using System;
using System.Collections.Generic;
using System.Text;

namespace Ahoy.Hotel.Core.Dtos
{
    public class HotelDto
    {
        public int HotelId { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }


        //public List<FacilityDto> Facilities { get; set; }
        public List<HotelFacilityDto> HotelFacility { get; set; }
    }
}
