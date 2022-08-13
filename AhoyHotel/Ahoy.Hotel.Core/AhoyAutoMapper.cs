using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Core.Models;
using Ahoy.Hotel.Core.Utilities;
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

            CreateMap<PagedResult<Models.Hotel>, PagedResponsResult<HotelDto>>().ReverseMap();

            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<PagedResult<Facility>, PagedResponsResult<FacilityDto>>().ReverseMap();
            CreateMap<HotelFacility, HotelFacilityDto>().ReverseMap();

            CreateMap<PagedResult<HotelFacility>, PagedResponsResult<HotelFacilityDto>>().ReverseMap();
            CreateMap<BookingDto, BookingRequestDto>()
                .ReverseMap();
            CreateMap<PagedResult<BookingDto>, PagedResponsResult<BookingRequestDto>>().ReverseMap();
            
            
            CreateMap<Booking, BookingDto>()
                .ForMember(x => x.CreatedOn, op => op.MapFrom(i => i.CreatedOn.ToLocalTime()));
          
            CreateMap<BookingDto, Booking>()
              .ForMember(x => x.CreatedOn, op => op.MapFrom(i => i.CreatedOn.ToUniversalTime()))
              .ForMember(x => x.Status, op => op.MapFrom(i => AhoyUtils.MapBookingEnum(i.Status)));

            CreateMap<PagedResult<Booking>, PagedResponsResult<BookingDto>>().ReverseMap();
        }
    }
}
