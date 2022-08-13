using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Core.Utilities;
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

        /// <summary>
        /// Get All Hotels/ Search by title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResponsResult<HotelDto> GetAll(string title = "", int page = 1, int pageSize = 20)
        {
            var result = _dbContext.Hotel.Include(x => x.HotelFacility).ThenInclude(x => x.Facility);
            IQueryable<Core.Models.Hotel> query = null;
            if (!string.IsNullOrEmpty(title))
            {
                query = result.Where(x => !x.IsDelete && x.IsActive && x.Title.ToLower().Contains(title.ToLower()));
            }
            else
            {
                query = result.Where(x => !x.IsDelete && x.IsActive);
            }
            var response = query.GetPaged(page, pageSize);
            return _mapper.Map<PagedResponsResult<HotelDto>>(response);
        }

        /// <summary>
        /// Get Hotel Details by Id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public async Task<HotelDto> Get(int hotelId)
        {
            var result = await _dbContext.Hotel.Include(x => x.HotelFacility).ThenInclude(x => x.Facility).FirstOrDefaultAsync(x => !x.IsDelete && x.IsActive && x.HotelId == hotelId);
            return _mapper.Map<HotelDto>(result);
        }
    }
}
