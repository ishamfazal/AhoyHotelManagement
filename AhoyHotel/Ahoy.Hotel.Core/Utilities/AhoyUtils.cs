using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Ahoy.Hotel.Core.Utilities
{
    public class AhoyUtils
    {

        public static string GenerateBookingReference()
        {
            var currentDate = DateTime.Now;
            var result = $"{currentDate:yyyy}{currentDate:MM}{currentDate:dd}{currentDate:hh}{currentDate:mm}{currentDate:ss}";
            return result;
        }


        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static string MapBookingEnum(BookingEnum value)
        {
            return value.ToString();
        }

    }
}
