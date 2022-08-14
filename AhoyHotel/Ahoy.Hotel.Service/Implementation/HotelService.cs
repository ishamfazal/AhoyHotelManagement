using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Repository.Interfaces;
using Ahoy.Hotel.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Service.Implementation
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository, ILogger<HotelService> logger)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<HotelDto> Get(int hotelId)
        {
            return await _hotelRepository.Get(hotelId);
        }

        public async Task<PagedResponsResult<HotelDto>> GetAll(string title = "", int page = 1, int pageSize = 20)
        {
            return await _hotelRepository.GetAll(title, page, pageSize);
        }
    }
}
