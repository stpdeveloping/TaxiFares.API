using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiFares.API.Domain.Exceptions
{
    public class MissingCompanyDataException : Exception
    {
        public MissingCompanyDataException(string missingProperty) :
            base(missingProperty)
        {
        }
    }
}
