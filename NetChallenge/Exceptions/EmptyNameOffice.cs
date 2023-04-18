using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class EmptyNameOffice: ArgumentException
    {
        public EmptyNameOffice(string message) : base(message)
        {

        }
    }
}
