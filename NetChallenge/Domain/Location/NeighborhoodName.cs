using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Location
{
    public class NeighborhoodName
    {
        public string Value { get; private set; }

        internal NeighborhoodName(string value)
        {
            this.Value = value;

        }

        public static NeighborhoodName Create(string value)
        {
            Validate(value);
            return new NeighborhoodName(value);

        }

        private static void Validate(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new EmptyNameNeighborhoode("Nombre de barrio invalido: No debe informarse vacio");

        }

    }
}
