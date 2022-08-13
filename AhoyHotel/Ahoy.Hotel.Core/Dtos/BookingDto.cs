using System;
using System.Collections.Generic;
using System.Text;

namespace Ahoy.Hotel.Core.Dtos
{
    public class BookingDto
    {
        public int BookingId { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string BookingReference { get; set; }
        public string Email { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfDays { get; set; }
        public BookingEnum Status { get; set; }
        public int NoOfPeople { get; set; }
        public HotelDto Hotel { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
