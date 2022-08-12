using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ahoy.Hotel.Core.Models;


namespace Ahoy.Hotel.EntityFramework.Core
{
    public class AhoyHotelContext : DbContext
    {
        public DbSet<Hotel.Core.Models.Hotel> Hotel { get; set; }
        public DbSet<HotelFacility> HotelFacility { get; set; }
        public DbSet<Facility> Facility { get; set; }


        public AhoyHotelContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel.Core.Models.Hotel>()
                .HasMany(e => e.HotelFacility);
        }

    }
}
