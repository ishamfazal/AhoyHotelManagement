using System;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Api.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<HotelService> _Logger;

        public HotelService(IHotelRepository hotelRepository, ILogger<HotelService> Logger)
        {
            _hotelRepository = hotelRepository;
            _Logger = Logger;
        }

        public async Task<HotelDto> Get(int hotelId)
        {
            return await _hotelRepository.Get(hotelId);
        }

        public async Task<List<HotelDto>> GetAll()
        {
            return await _hotelRepository.GetAll();
        }
    }
}
