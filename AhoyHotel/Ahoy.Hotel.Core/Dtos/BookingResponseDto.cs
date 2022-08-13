using System;
using System.Collections.Generic;
using System.Text;

namespace Ahoy.Hotel.Core.Dtos
{
    public class BookingResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string BookingReference { get; set; }
    }
}
