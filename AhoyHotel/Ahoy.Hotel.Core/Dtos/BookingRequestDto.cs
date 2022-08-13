using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;
using static Ahoy.Hotel.Core.Utilities.AhoyUtils;

namespace Ahoy.Hotel.Core.Dtos
{
    public class BookingRequestDto
    {
        [Required]
        [StringLength(64)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        public string BookingReference { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        [Required]
        public BookingEnum Status { get; set; }
        [Required]
        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "Not Equal to Zero")]
        public int NoOfPeople { get; set; }
        [Required]
        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "Not Equal to Zero")]
        public int HotelId { get; set; }
    }
}
