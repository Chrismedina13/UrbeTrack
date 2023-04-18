using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class EmptyNameNeighborhoode: ArgumentException
    {
        public EmptyNameNeighborhoode(string message) : base(message)
        {

        }
    }
}
