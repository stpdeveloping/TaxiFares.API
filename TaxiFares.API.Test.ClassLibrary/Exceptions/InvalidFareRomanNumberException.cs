using System;

namespace TaxiFares.API.Test.ClassLibrary.Exceptions
{
    public class InvalidFareRomanNumberException : Exception
    {
        public InvalidFareRomanNumberException(
            string fareRomanNumber) : base(fareRomanNumber)
        {
        }
    }
}
