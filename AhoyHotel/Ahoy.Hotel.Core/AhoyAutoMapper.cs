using System;
using System.Collections.Generic;
using System.Linq;
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
            //while mapping convert utc datetime to local timezone value
            CreateMap<Models.Hotel, HotelDto>()
                .ForMember(x => x.CreatedOn, op => op.MapFrom(i => i.CreatedOn.ToLocalTime()))
                .ReverseMap();
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<HotelFacility, HotelFacilityDto>().ReverseMap();
        }
    }
}
