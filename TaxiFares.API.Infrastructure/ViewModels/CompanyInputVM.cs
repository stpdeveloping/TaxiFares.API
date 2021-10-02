using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.Infrastructure.ViewModels
{
    public class CompanyInputVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CityName { get; set; }
        [JsonPropertyName("fares"), Required]
        public FaresViewModel FaresViewModel { get; set; }
    }
}
