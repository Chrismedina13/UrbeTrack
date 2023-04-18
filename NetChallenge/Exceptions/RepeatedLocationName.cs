using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class RepeatedLocationName: ArgumentException
    {
        public RepeatedLocationName(string message) : base(message)
        {

        }
    }
}
