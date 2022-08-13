using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ahoy.Hotel.Core.Utilities
{
    public class AhoyUtils
    {

        public static string GenerateBookingReference()
        {
            var rand = new Random();
            var currentDate = DateTime.Now;
            var result = $"{currentDate.Year}{currentDate.Month}{currentDate.Date}{currentDate.Hour}{currentDate.Minute}{currentDate.Second}{rand.Next()}";
            return result;
        }


        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
