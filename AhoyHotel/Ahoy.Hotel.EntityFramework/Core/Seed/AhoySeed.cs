using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ahoy.Hotel.Core.Models;
using Microsoft.Extensions.Configuration;

namespace Ahoy.Hotel.EntityFramework.Core.Seed
{
    public class AhoySeed
    {
        private readonly AhoyHotelContext _dbContext;

        public AhoySeed(AhoyHotelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create()
        {
            CreateInitData();
        }

        private void CreateInitData()
        {
            if (!_dbContext.Hotel.Any())
            {
                var hotels = new List<Hotel.Core.Models.Hotel>()
                {
                    new Hotel.Core.Models.Hotel()
                    {
                        Title = "The First Collection Business BayOpens in new window",
                        Description = "The First Collection Business Bay is a modern, stylish hotel located in the Business Bay district and is 1 mi away from Dubai Mall and the Burj Khalifa.",
                        Address="Business Bay, Dubai",
                        Price=200,
                        Rating=4.5f
                    },
                     new Hotel.Core.Models.Hotel()
                    {
                        Title = "Millennium Place Barsha Heights Hotel",
                        Description = "Located in Dubai, 1.5 miles from Mina Seyahi Beach, Millennium Place Barsha Heights Hotel provides accommodations with a restaurant, free private parking, a fitness center and a terrace.",
                        Address="Barsha Heights (Tecom) , Dubai",
                        Price=300,
                        Rating=4.0f
                    },
                      new Hotel.Core.Models.Hotel()
                    {
                        Title = "The First Collection at Jumeirah Village",
                        Description = "The First Collection at Jumeirah Village Circle is located in the district of JVC. The 41-story high-rise hotel features 491 fully equipped guestrooms.",
                        Address="Dubai",
                        Price=250,
                        Rating=3.5f
                    },
                    new Hotel.Core.Models.Hotel()
                    {
                        Title = "Opens in new window Swissôtel Al Murooj DubaiOpens in new window",
                        Description = "Five-star Swissôtel Al Murooj Dubai is located across from Dubai Mall and the famous Burj Khalifa. It features a lush garden with a large swimming pool and free WiFi in public areas.",
                        Address="Trade Center Area, Dubai",
                        Price=150,
                        Rating=2.0f
                    },
                     new Hotel.Core.Models.Hotel()
                    {
                        Title = "Radisson Blu Hotel, Dubai Deira Creek",
                        Description = "The Radisson Blu lies within the beautiful Deira Creek area of Dubai, a short walk to the bus and metro stations and only 4.3 miles from Dubai International Airport.",
                        Address="Deira, Dubai",
                        Price=300,
                        Rating=4.0f
                    },
                };


                _dbContext.AddRange(hotels);
                _dbContext.SaveChanges();
            }



            if (!_dbContext.Facility.Any())
            {
                var facility = new List<Facility>()
                {
                    new Facility()
                    {
                        Title = "Breakfast",
                        Description="Breakfast"
                    },
                    new Facility()
                    {
                        Title = "Wi-Fi",
                        Description="Wi-Fi"
                    },
                    new Facility()
                    {
                        Title = "Parking",
                        Description="Parking"
                    },
                    new Facility()
                    {
                        Title = "Spa",
                        Description="Spa"
                    }
                };


                _dbContext.AddRange(facility);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.HotelFacility.Any())
            {
                var hotels = _dbContext.Hotel.ToList();
                var facilities = _dbContext.Facility.ToList();

                foreach (var hotel in hotels)
                {
                    foreach (var facility in facilities)
                    {
                        if (!_dbContext.HotelFacility.Any(x => x.HotelId == hotel.HotelId && x.FacilityId == facility.FacilityId))
                        {
                            _dbContext.HotelFacility.Add(new HotelFacility() { FacilityId = facility.FacilityId, Facility = facility, Hotel = hotel, HotelId = hotel.HotelId });
                            _dbContext.SaveChanges();
                        }

                    }

                }
            }
        }
    }
}
