using System.IO;
using System.Threading.Tasks;

namespace TaxiFares.API.Infrastructure.Extensions
{
    public static class StreamExtension
    {
        public static async Task<string> ReadToEndAsync(
            this Stream stream)
        {
            var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }
    }
}
