namespace TaxiFares.API.Domain.Exceptions
{
    public class MissingCompanyDataException : MissingDataException
    {
        public MissingCompanyDataException(string propertyName) :
            base(propertyName)
        {
        }
    }
}
