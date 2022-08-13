using Ahoy.Hotel.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Api.Services
{
    public interface IBookingService
    {
        public PagedResponsResult<BookingDto> GetAll(int page = 1, int pageSize = 20);

        Task<BookingResponseDto> BookHotel(BookingRequestDto requestDto);

        Task<BookingDto> Get(int bookingId);
    }
}
