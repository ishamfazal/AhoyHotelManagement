using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ahoy.Hotel.Core.Models
{
    [Table(nameof(Hotel))]
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }


        public List<HotelFacility> HotelFacility { get; set; }

        public Hotel()
        {
            this.IsActive = true;
            this.CreatedOn = DateTime.UtcNow;
            this.IsDelete = false;
        }
    }
}
