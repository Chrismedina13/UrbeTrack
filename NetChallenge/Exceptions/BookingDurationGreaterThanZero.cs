using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    class BookingDurationGreaterThanZero: ArgumentException
    {
        public BookingDurationGreaterThanZero(string message) : base(message)
        {

        }
    }
}
