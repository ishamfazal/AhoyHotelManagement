using System;
using System.Collections.Generic;
using System.Text;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Core.Models;
using AutoMapper;

namespace Ahoy.Hotel.Core
{
    public class AhoyAutoMapper : Profile
    {
        public AhoyAutoMapper()
        {
            CreateMap<Models.Hotel, HotelDto>();
            CreateMap<Facility, FacilityDto>();
            CreateMap<HotelFacility, HotelFacilityDto>();
        }
    }
}
