using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    class OverlapingDatetime: ArgumentException
    {
        public OverlapingDatetime(string message) : base(message)
        {

        }
    }
}
