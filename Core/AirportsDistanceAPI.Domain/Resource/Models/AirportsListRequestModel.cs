using System.ComponentModel.DataAnnotations;

namespace AirportsDistanceAPI.Domain.Resource.Models
{
    public class AirportsListRequestModel
    {
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "3 characters must be entered, please enter only 3 characters...")]
        public string? IATA1 { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "3 characters must be entered, please enter only 3 characters...")]
        public string? IATA2 { get; set; }
    }
}
