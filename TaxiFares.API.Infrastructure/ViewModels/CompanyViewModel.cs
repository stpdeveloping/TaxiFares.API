using System.Text.Json.Serialization;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.Infrastructure.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        [JsonPropertyName("fares")]
        public FaresViewModel FaresViewModel { get; set; }
    }
}
