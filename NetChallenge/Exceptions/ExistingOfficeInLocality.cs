using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    class ExistingOfficeInLocality: ArgumentException
    {
        public ExistingOfficeInLocality(string message) : base(message)
        {

        }
    }
}
