using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Booking
{
    public class BookingDatetime
    {

        public DateTime Value { get; private set; }

        internal BookingDatetime(DateTime value)
        {
            this.Value = value;

        }

        public static BookingDatetime Create(DateTime value)
        {
            return new BookingDatetime(value);

        }

    }
}
