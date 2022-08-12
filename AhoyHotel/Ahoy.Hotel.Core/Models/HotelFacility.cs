using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ahoy.Hotel.Core.Models
{
    [Table(nameof(HotelFacility))]
    public class HotelFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        public bool IsDelete { get; set; }


        public HotelFacility()
        {
            this.IsDelete = false;
        }

    }
}
