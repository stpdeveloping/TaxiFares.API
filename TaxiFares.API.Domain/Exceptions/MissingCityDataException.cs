namespace TaxiFares.API.Domain.Exceptions
{
    public class MissingCityDataException : MissingDataException
    {
        public MissingCityDataException(string propertyName) :
            base(propertyName)
        {
        }
    }
}
