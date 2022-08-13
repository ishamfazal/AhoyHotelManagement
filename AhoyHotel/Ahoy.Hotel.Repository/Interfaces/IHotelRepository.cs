using Ahoy.Hotel.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahoy.Hotel.Repository.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<HotelDto>> GetAll();
    }
}
