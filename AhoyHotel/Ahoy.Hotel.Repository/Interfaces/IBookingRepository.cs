using Ahoy.Hotel.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Repository.Interfaces
{
    public interface IBookingRepository
    {
        public PagedResponsResult<BookingDto> GetAll(int page = 1, int pageSize = 20);

        Task<BookingResponseDto> BookHotel(BookingDto requestDto);

        Task<List<BookingDto>> CheckAvailablity(int hotelId, DateTime checkInDate, DateTime checkedOutDate);

        Task<BookingDto> Get(int bookingId);
    }
}
