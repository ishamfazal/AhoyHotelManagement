using Ahoy.Hotel.Repository.Interfaces;

namespace Ahoy.Hotel.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository, IHotelRepository hotelRepository)
        {
            this._bookingRepository = bookingRepository;
            this._hotelRepository = hotelRepository;
        }


    }
}
