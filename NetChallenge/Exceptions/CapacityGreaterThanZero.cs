using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class CapacityGreaterThanZero: ArgumentException
    {
        public CapacityGreaterThanZero(string message) : base(message)
        {

        }
    }
}
