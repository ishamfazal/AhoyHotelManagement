using Ahoy.Hotel.Api.Controllers;
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
            var okResult = bookingsController.Get(1);
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
