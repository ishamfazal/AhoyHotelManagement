using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.EntityFramework.Core;
using Ahoy.Hotel.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Repository.Implementaion
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AhoyHotelContext _dbContext;
        private readonly IMapper _mapper;

        public HotelRepository(AhoyHotelContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<HotelDto>> GetAll()
        {
            var result = await _dbContext.Hotel.Include(x => x.HotelFacility).ThenInclude(x => x.Facility).ToListAsync();
            return _mapper.Map<List<HotelDto>>(result);
        }


        public async Task<HotelDto> Get(int hotelId)
        {
            var result = await _dbContext.Hotel.Include(x => x.HotelFacility).ThenInclude(x => x.Facility).FirstOrDefaultAsync(x => x.HotelId == hotelId);
            return _mapper.Map<HotelDto>(result);
        }
    }
}
