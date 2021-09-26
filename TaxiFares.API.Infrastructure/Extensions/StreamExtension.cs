using System.IO;

namespace TaxiFares.API.Infrastructure.Extensions
{
    public static class StreamExtension
    {
        public static string ReadToEnd(this Stream stream)
        {
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}
