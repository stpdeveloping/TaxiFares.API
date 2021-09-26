using TaxiFares.API.Infrastructure;

namespace TaxiFares.API.Test.ClassLibrary
{
    public class Config
    {
        public static readonly string[] CommandArgs = new string[]
            {
                "--environment", EnvironmentNames.Test
            };
    }
}
