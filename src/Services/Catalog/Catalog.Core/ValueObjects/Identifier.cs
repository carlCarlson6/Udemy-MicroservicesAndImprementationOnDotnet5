using System;

namespace Catalog.Core.ValueObjects
{
    public class Identifier
    {
        private readonly string _value;

        public Identifier(string value)
        {
            Validate(value);
            _value = value;
        }

        private static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(value);
            }
        }
        
        public override string ToString() => _value;
    }
}