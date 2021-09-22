namespace TaxiFares.API.Infrastructure
{
    public class SqlFileNames
    {
        public readonly static string CreateTriggerOnFaresUpdate =
            $"{nameof(CreateTriggerOnFaresUpdate)}.sql";
    }
}
