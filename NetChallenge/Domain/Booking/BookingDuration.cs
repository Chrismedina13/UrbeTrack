using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Booking
{
    public class BookingDuration
    {
        public TimeSpan Value { get; private set; }

        internal BookingDuration(TimeSpan value)
        {
            this.Value = value;

        }

        public static BookingDuration Create(TimeSpan value)
        {
            Validate(value);
            return new BookingDuration(value);

        }

        private static void Validate(TimeSpan value)
        {
            if (value.TotalMinutes <=  0)
                throw new BookingDurationGreaterThanZero("El tiempo reservado debe ser mayor a 0");

        }
    }
}
