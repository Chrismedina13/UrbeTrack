using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Office
{
    public class AvailableResource
    {
        public string Value { get; private set; }

        internal AvailableResource(string value)
        {
            this.Value = value;

        }

        public static AvailableResource Create(string value)
        {
            return new AvailableResource(value);

        }


    }
}
