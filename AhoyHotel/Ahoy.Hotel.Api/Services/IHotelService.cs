using Ahoy.Hotel.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Api.Services
{
    public interface IHotelService
    {
        PagedResponsResult<HotelDto> GetAll(string title = "", int page = 1, int pageSize = 20);

        Task<HotelDto> Get(int hotelId);
    }
}
