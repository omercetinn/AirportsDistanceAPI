using AirportsDistanceAPI.Domain.Resource.Models;
using FluentValidation;

namespace AirportsDistanceAPI.Application.Business.ValidationRules.FluentValidation
{
    public class AirportsDistanceValidator : AbstractValidator<AirportsListRequestModel>
    {
        public AirportsDistanceValidator()
        {
            RuleFor(p => p.IATA1).MaximumLength(3);
            RuleFor(p => p.IATA2).MaximumLength(3);
        }
    }
}
