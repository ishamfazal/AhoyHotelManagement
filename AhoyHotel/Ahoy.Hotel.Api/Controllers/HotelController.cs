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
        private readonly IMapper _mapper;
        private readonly IHotelService _hotelService;

        public HotelController(IMapper mapper, IHotelService hotelService)
        {
            _mapper = mapper;
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _hotelService.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int hotelId)
        {
            return Ok(await _hotelService.Get(hotelId));
        }
    }
}
