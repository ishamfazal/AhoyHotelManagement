using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this._bookingService = bookingService;
        }

        /// <summary>
        /// Get All Booking Details
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 20)
        {
            return Ok(_bookingService.GetAll(page, pageSize));
        }

        /// <summary>
        /// Place booking of a hotel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingRequestDto request)
        {
            var response = await _bookingService.BookHotel(request);
            return Ok(response);
        }

        /// <summary>
        /// Get a specific Booking details
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int bookingId)
        {
            var response = await _bookingService.Get(bookingId);
            return Ok(response);
        }

        /// <summary>
        /// Check availablity of the hotel before booking
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkedOutDate"></param>
        /// <returns></returns>
        [HttpGet("CheckAvailability")]
        public async Task<IActionResult> CheckAvailability(int hotelId, DateTime checkInDate, DateTime checkedOutDate)
        {
            var response = await _bookingService.CheckAvailablity(hotelId, checkInDate, checkedOutDate);
            return Ok(response);
        }


    }
}
