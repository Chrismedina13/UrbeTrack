using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    class InvalidOffice: ArgumentException
    {
        public InvalidOffice(string message) : base(message)
        {

        }
    }
}
