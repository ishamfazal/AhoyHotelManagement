using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ahoy.Hotel.Core.Models
{
    [Table(nameof(Facility))]
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public Facility()
        {
            this.IsActive = true;
            this.CreatedOn = DateTime.UtcNow;
            this.IsDelete = false;
        }
    }
}
