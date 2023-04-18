using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class EmptyNameLocation: ArgumentException
    {
        public EmptyNameLocation(string message): base(message)
        {
            
        }
    }
}
