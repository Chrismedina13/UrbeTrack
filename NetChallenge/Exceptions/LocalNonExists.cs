using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    class LocalNonExists: ArgumentException
    {
        public LocalNonExists(string message) : base(message)
        {

        }
    }
}
