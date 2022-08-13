using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.UnitTest
{
    public class HotelFakeService : IHotelService
    {
        private readonly List<HotelDto> _hotelList;
        public HotelFakeService()
        {
            _hotelList = new List<HotelDto>()
            {
                 new HotelDto()
                    {
                        HotelId = 1,
                        Title = "The First Collection Business BayOpens in new window",
                        Description = "The First Collection Business Bay is a modern, stylish hotel located in the Business Bay district and is 1 mi away from Dubai Mall and the Burj Khalifa.",
                        Address="Business Bay, Dubai",
                        Price=200,
                        Rating=4.5f
                    },
                     new HotelDto()
                    {
                        HotelId = 2,
                        Title = "Millennium Place Barsha Heights Hotel",
                        Description = "Located in Dubai, 1.5 miles from Mina Seyahi Beach, Millennium Place Barsha Heights Hotel provides accommodations with a restaurant, free private parking, a fitness center and a terrace.",
                        Address="Barsha Heights (Tecom) , Dubai",
                        Price=300,
                        Rating=4.0f
                    },
                      new HotelDto()
                    {
                        HotelId = 3,
                        Title = "The First Collection at Jumeirah Village",
                        Description = "The First Collection at Jumeirah Village Circle is located in the district of JVC. The 41-story high-rise hotel features 491 fully equipped guestrooms.",
                        Address="Dubai",
                        Price=250,
                        Rating=3.5f
                    },
                    new HotelDto()
                    {
                        HotelId = 4,
                        Title = "Opens in new window Swissôtel Al Murooj DubaiOpens in new window",
                        Description = "Five-star Swissôtel Al Murooj Dubai is located across from Dubai Mall and the famous Burj Khalifa. It features a lush garden with a large swimming pool and free WiFi in public areas.",
                        Address="Trade Center Area, Dubai",
                        Price=150,
                        Rating=2.0f
                    },
                     new HotelDto()
                    {
                        HotelId = 5,
                        Title = "Radisson Blu Hotel, Dubai Deira Creek",
                        Description = "The Radisson Blu lies within the beautiful Deira Creek area of Dubai, a short walk to the bus and metro stations and only 4.3 miles from Dubai International Airport.",
                        Address="Deira, Dubai",
                        Price=300,
                        Rating=4.0f
                    }
            };
        }
        public async Task<HotelDto> Get(int hotelId)
        {
            return _hotelList.Find(x => x.HotelId == hotelId);
        }

        public PagedResponsResult<HotelDto> GetAll(string title = "", int page = 1, int pageSize = 20)
        {
            var result = new PagedResponsResult<HotelDto>();
            if (!string.IsNullOrEmpty(title))
            {
                result.Results = _hotelList.FindAll(x => x.Title.ToLower().Contains(title.ToLower()));
                result.CurrentPage = page;
                result.PageSize = pageSize;
                result.PageCount = result.Results.Count;
            }
            else
            {
                result.Results = _hotelList;
                result.CurrentPage = page;
                result.PageSize = pageSize;
                result.PageCount = result.Results.Count;
            }
            return result;
        }
    }
}
