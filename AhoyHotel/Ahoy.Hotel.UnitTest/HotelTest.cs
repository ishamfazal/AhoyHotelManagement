using Ahoy.Hotel.Api.Controllers;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ahoy.Hotel.UnitTest
{
    public class HotelTest
    {
        private readonly IHotelService hotelService;
        private readonly HotelController _hotelController;

        public HotelTest()
        {
            hotelService = new HotelFakeService();
            _hotelController = new HotelController(hotelService);
        }

        [Fact]
        public void GetAll_Success()
        {
            var okResult = _hotelController.Get();
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetAll_ReturnAll()
        {

            var okResult = _hotelController.Get() as OkObjectResult;
            var items = Assert.IsType<PagedResponsResult<HotelDto>>(okResult?.Value);
            Assert.NotEmpty(items.Results);
        }

        [Fact]
        public void GetAll_Search()
        {

            var okResult = _hotelController.Get("The first") as OkObjectResult;
            var items = Assert.IsType<PagedResponsResult<HotelDto>>(okResult?.Value);
            Assert.NotEmpty(items.Results);
        }


        [Fact]
        public void Get_HotelById()
        {
            var okResult = (_hotelController.GetById(1).Result) as OkObjectResult;
            var items = Assert.IsType<HotelDto>(okResult?.Value);
            Assert.NotNull(items);
        }
    }
}
