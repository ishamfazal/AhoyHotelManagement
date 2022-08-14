using Ahoy.Hotel.Core;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Core.Utilities;
using Ahoy.Hotel.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.UnitTest
{
    internal class FakeBookingService : IBookingService
    {
        private readonly List<BookingDto> _bookingDtos;

        public FakeBookingService()
        {
            _bookingDtos = new List<BookingDto>()
            {
                new BookingDto()
                {
                    BookingId=1,
                    BookingReference = AhoyUtils.GenerateBookingReference(),
                    CheckInDate = DateTime.Now.AddDays(-5),
                    CheckOutDate=DateTime.Now.AddDays(-4),
                    CustomerName="Isham",
                    Email="ishamfazal@gmail.com",
                    NoOfPeople =2,
                    PhoneNumber = "0509204836",
                    Hotel=new HotelDto()
                     {
                        HotelId = 1,
                        Title = "The First Collection Business BayOpens in new window",
                        Description = "The First Collection Business Bay is a modern, stylish hotel located in the Business Bay district and is 1 mi away from Dubai Mall and the Burj Khalifa.",
                        Address="Business Bay, Dubai",
                        Price=200,
                        Rating=4.5f
                    },
                    Status=Core.BookingEnum.Booked
                }
            };
        }

        public Task<BookingResponseDto> BookHotel(BookingRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDto>> CheckAvailablity(int hotelId, DateTime checkInDate, DateTime checkedOutDate)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingDto> Get(int bookingId)
        {
            return _bookingDtos.FirstOrDefault(x => x.BookingId == bookingId);
        }

        public PagedResponsResult<BookingDto> GetAll(int page = 1, int pageSize = 20)
        {
            return new PagedResponsResult<BookingDto>
            {
                Results = _bookingDtos,
                CurrentPage = page,
                PageSize = pageSize,
                PageCount = _bookingDtos.Count
            };
        }
    }
}
