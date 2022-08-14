using Ahoy.Hotel.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Service.Interface
{
    public interface IHotelService
    {
        Task<PagedResponsResult<HotelDto>> GetAll(string title = "", int page = 1, int pageSize = 20);

        Task<HotelDto> Get(int hotelId);
    }
}
