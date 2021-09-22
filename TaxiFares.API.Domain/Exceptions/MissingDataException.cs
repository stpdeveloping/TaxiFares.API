using System;
using TaxiFares.API.Domain.Properties;

namespace TaxiFares.API.Domain.Exceptions
{
    public class MissingDataException : Exception
    {
        public MissingDataException(string propName) :
            base(string.Format(Resources.MissingPropLabel, propName))
        {
        }
    }
}
