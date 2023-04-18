using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Office
{
    public class MaxCapacity
    {
        public int Value { get; private set; }

        internal MaxCapacity(int value)
        {
            this.Value = value;

        }

        public static MaxCapacity Create(int value)
        {
            Validate(value);
            return new MaxCapacity(value);

        }

        private static void Validate(int value)
        {
            if (value <= 0 )
                throw new CapacityGreaterThanZero("La capacidad maxima debe ser mayor a 0");

        }
    }
}
