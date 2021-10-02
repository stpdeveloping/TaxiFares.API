namespace TaxiFares.API.Infrastructure
{
    public class SqlFileNames
    {
        public static readonly string CreateTriggerOnFaresUpdate =
            $"{nameof(CreateTriggerOnFaresUpdate)}.sql";
    }
}
