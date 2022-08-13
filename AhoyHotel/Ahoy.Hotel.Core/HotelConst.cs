using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ahoy.Hotel.Core
{
    public class HotelConst
    {
        public const string ConnectionStringName = "AhoyConnection";
    }

    public enum BookingEnum
    {
        [Description("Booked")]
        Booked,
        [Description("Cancelled")]
        Cancelled,
        [Description("Pending Payment")]
        PendingPayment,
        [Description("Checked Out")]
        CheckedOut,
        [Description("Checked In")]
        CheckedIn
    }

}
