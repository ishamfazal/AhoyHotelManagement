using Ahoy.Hotel.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotel details and Search by Title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string title = "", int page = 1, int pageSize = 20)
        {
            return Ok(_hotelService.GetAll(title, page, pageSize));
        }

        /// <summary>
        /// Get Specific Hotel Details
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int hotelId)
        {
            return Ok(await _hotelService.Get(hotelId));
        }
    }
}
