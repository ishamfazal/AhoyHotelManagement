using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.EntityFramework.Core;
using Ahoy.Hotel.Repository.Interfaces;
using AutoMapper;
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
            var result = _dbContext.Hotel.ToList();
            return _mapper.Map<List<HotelDto>>(result);
        }
    }
}
