using System;
using System.Collections.Generic;
using System.Text;

namespace Ahoy.Hotel.Core
{
    public class AhoyExceptionResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public AhoyExceptionResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
        }
    }
}
