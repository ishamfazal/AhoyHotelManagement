using Ahoy.Hotel.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Api.Services
{
    public interface IHotelService
    {
        Task<List<HotelDto>> GetAll();

        Task<HotelDto> Get(int hotelId);
    }
}
