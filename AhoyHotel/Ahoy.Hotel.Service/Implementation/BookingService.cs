using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Repository.Interfaces;
using Ahoy.Hotel.Service.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IHotelRepository hotelRepository, IMapper mapper)
        {
            this._bookingRepository = bookingRepository;
            this._mapper = mapper;
        }

        public async Task<PagedResponsResult<BookingDto>> GetAll(int page = 1, int pageSize = 20)
        {
            return await _bookingRepository.GetAll(page, pageSize);
        }


        public async Task<BookingResponseDto> BookHotel(BookingRequestDto requestDto)
        {
            var request = _mapper.Map<BookingDto>(requestDto);
            request.CheckInDate = requestDto.CheckInDate.Date;
            request.CheckOutDate = requestDto.CheckOutDate.Date;
            request.NoOfDays = (int)requestDto.CheckOutDate.Subtract(requestDto.CheckInDate).TotalDays;

            var existBookings = await _bookingRepository.CheckAvailablity(requestDto.HotelId, request.CheckInDate, request.CheckOutDate);
            if (existBookings != null && existBookings.Any())
            {
                return new BookingResponseDto() { BookingReference = "", IsSuccess = false, Message = "Unable to book during these days, the hotel is already booked" };
            }
            return await _bookingRepository.BookHotel(request);
        }

        public async Task<BookingDto> Get(int bookingId)
        {
            return await _bookingRepository.Get(bookingId);
        }


        public async Task<List<BookingDto>> CheckAvailablity(int hotelId, DateTime checkInDate, DateTime checkedOutDate)
        {
            return await _bookingRepository.CheckAvailablity(hotelId, checkInDate, checkedOutDate);
        }
    }
}
