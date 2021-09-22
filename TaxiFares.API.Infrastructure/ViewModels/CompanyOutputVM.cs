using System.Text.Json.Serialization;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.Infrastructure.ViewModels
{
    public class CompanyOutputVM
    {
        public string Name { get; set; }
        [JsonPropertyName("fares")]
        public FaresViewModel FaresViewModel { get; set; }
    }
}
