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
        private readonly HotelController hotelController;

        public HotelTest()
        {
            hotelService = new HotelFakeService();
            hotelController = new HotelController(hotelService);
        }

        [Fact]
        public void GetAll_Success()
        {
            var okResult = hotelController.Get();
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetAll_ReturnAll()
        {

            var okResult = hotelController.Get() as OkObjectResult;
            var items = Assert.IsType<PagedResponsResult<HotelDto>>(okResult.Value);
            Assert.NotEmpty(items.Results);
        }

        [Fact]
        public void GetAll_Search()
        {

            var okResult = hotelController.Get("The first") as OkObjectResult;
            var items = Assert.IsType<PagedResponsResult<HotelDto>>(okResult.Value);
            Assert.NotEmpty(items.Results);
        }


        [Fact]
        public void Get_HotelById()
        {
            var okResult = (hotelController.GetById(1).Result) as OkObjectResult;
            var items = Assert.IsType<HotelDto>(okResult.Value);
            Assert.NotNull(items);
        }
    }
}
