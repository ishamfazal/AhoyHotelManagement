using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ahoy.Hotel.Api.Controllers
{
    [Route("")]
    public class AhoyHotelController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<AhoyHotelController> _Logger;

        public AhoyHotelController(IConfiguration configuration, ILogger<AhoyHotelController> logger)
        {
            this.configuration = configuration;
            this._Logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Content($"Ahoy Hotel Management Api v({configuration.GetSection("build").Value}) Started!");
        }
    }
}
