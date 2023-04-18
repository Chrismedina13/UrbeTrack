using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain.Booking
{
    public class UserName
    {
        public string Value { get; private set; }

        internal UserName(string value)
        {
            this.Value = value;

        }

        public static UserName Create(string value)
        {
            Validate(value);
            return new UserName(value);

        }

        private static void Validate(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new EmptyUserName("Usuario invalido: No debe informarse vacio");

        }
    }
}
