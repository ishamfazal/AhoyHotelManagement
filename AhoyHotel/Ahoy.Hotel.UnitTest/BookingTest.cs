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
    public class BookingTest
    {
        private readonly IBookingService bookingService;
        private readonly BookingsController bookingsController;

        public BookingTest()
        {
            bookingService = new FakeBookingService();
            bookingsController = new BookingsController(bookingService);
        }

        [Fact]
        public void GetById_Success()
        {
            var okResult = bookingsController.GetById(1);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetByIdNotNull()
        {
            var okResult = bookingsController.GetById(1).Result as OkObjectResult;
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetAll_ReturnAll()
        {
            var okResult = bookingsController.Get() as OkObjectResult;
            var items = Assert.IsType<PagedResponsResult<BookingDto>>(okResult.Value);
            Assert.NotEmpty(items.Results);
        }
    }
}
