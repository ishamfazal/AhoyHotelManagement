using Ahoy.Hotel.Api.Controllers;
using Ahoy.Hotel.Core.Dtos;
using Ahoy.Hotel.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ahoy.Hotel.UnitTest
{
    public class BookingTest
    {
        private readonly BookingsController _bookingsController;

        public BookingTest()
        {
            IBookingService bookingService = new FakeBookingService();
            _bookingsController = new BookingsController(bookingService);
        }

        [Fact]
        public void GetById_Success()
        {
            var okResult = _bookingsController.GetById(1);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetByIdNotNull()
        {
            var okResult = _bookingsController.GetById(1).Result as OkObjectResult;
            Assert.NotNull(okResult?.Value);
        }

        [Fact]
        public void GetAll_ReturnAll()
        {
            var okResult = _bookingsController.Get().Result as OkObjectResult;
            var items = Assert.IsType<PagedResponsResult<BookingDto>>(okResult?.Value);
            Assert.NotEmpty(items.Results);
        }
    }
}
