using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Location
{
    public class LocationName
    {
        public string Value { get; private set; }

        internal LocationName(string value)
        {
            this.Value = value;

        }

        public static LocationName Create(string value) 
        {
            Validate(value);
            return new LocationName(value);
        
        }

        private static void Validate(string value) 
        {
            if (String.IsNullOrEmpty(value))
                throw new EmptyNameLocation("Nombre de locación invalido: No debe informarse vacio");

        }
    }
}
