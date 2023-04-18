using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Office
{
    public class OfficeName
    {
        public string Value { get; private set; }

        internal OfficeName(string value)
        {
            this.Value = value;

        }

        public static OfficeName Create(string value)
        {
            Validate(value);
            return new OfficeName(value);

        }

        private static void Validate(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new EmptyNameOffice("Nombre de oficina invalido: No debe informarse vacio");

        }
    }
}
