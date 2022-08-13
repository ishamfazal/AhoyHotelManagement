using Ahoy.Hotel.Api.Services;
using Ahoy.Hotel.Core.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 20)
        {
            return Ok(_bookingService.GetAll(page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingRequestDto request)
        {
            var response = await _bookingService.BookHotel(request);
            return Ok(response);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int bookingId)
        {
            var response = await _bookingService.Get(bookingId);
            return Ok(response);
        }

    }
}
