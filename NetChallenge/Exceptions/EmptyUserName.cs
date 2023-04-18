using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    class EmptyUserName: ArgumentException
    {
        public EmptyUserName(string message) : base(message)
        {

        }
    }
}
