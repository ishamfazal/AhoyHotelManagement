using Ahoy.Hotel.Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ahoy.Hotel.Core.Models
{
    [Table(nameof(Booking))]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string BookingReference { get; set; }
        public string Email { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfDays { get; set; }
        public string Status { get; set; }
        public int NoOfPeople { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public Booking()
        {
            this.IsActive = true;
            this.CreatedOn = DateTime.UtcNow;
            this.IsDelete = false;
        }

    }
}
