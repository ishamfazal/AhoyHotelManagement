using Ahoy.Hotel.Core;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Core.Models;
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
    public class BookingRepository : IBookingRepository
    {
        private readonly AhoyHotelContext _dbContext;
        private readonly IMapper _mapper;

        public BookingRepository(AhoyHotelContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Book Hotel
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public async Task<BookingResponseDto> BookHotel(BookingDto requestDto)
        {
            var request = _mapper.Map<Booking>(requestDto);
            request.BookingReference = AhoyUtils.GenerateBookingReference();
            request.CreatedOn = DateTime.UtcNow;
            request.IsDelete = false;
            request.IsActive = true;
            await _dbContext.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return new BookingResponseDto() { BookingReference = request.BookingReference, IsSuccess = true, Message = "" };
        }

        /// <summary>
        /// Get All Booking Details
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PagedResponsResult<BookingDto>> GetAll(int page = 1, int pageSize = 20)
        {
            var result = await _dbContext.Booking.Include(x => x.Hotel).Where(x => !x.IsDelete && x.IsActive).GetPagedAsync(page, pageSize);
            return _mapper.Map<PagedResponsResult<BookingDto>>(result);
        }

        public async Task<BookingDto> Get(int bookingId)
        {
            var result = await _dbContext.Booking.Include(x => x.Hotel).ThenInclude(x => x.HotelFacility).ThenInclude(x => x.Facility).AsNoTracking().FirstOrDefaultAsync(x => !x.IsDelete && x.IsActive && x.BookingId == bookingId);
            return _mapper.Map<BookingDto>(result);
        }

        /// <summary>
        /// Check Availablity Of the booking hotel, before booking
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkedOutDate"></param>
        /// <returns></returns>
        public async Task<List<BookingDto>> CheckAvailablity(int hotelId, DateTime checkInDate, DateTime checkedOutDate)
        {
            var result = await _dbContext.Booking.Include(x => x.Hotel)
                .Where(x => !x.IsDelete
                            && x.IsActive
                            && (((x.CheckInDate <= checkInDate || checkInDate <= x.CheckOutDate) && checkedOutDate <= x.CheckOutDate)
                            || (checkInDate <= x.CheckInDate && x.CheckOutDate <= checkedOutDate))
                            && x.Status == BookingEnum.Booked.ToString()
                            && x.HotelId == hotelId).AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<BookingDto>>(result);
        }
    }
}
