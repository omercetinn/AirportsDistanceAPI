using AirportsDistanceAPI.Domain.Resource.Models;

namespace AirportsDistanceAPI.Application.Abstraction
{
    public interface IAirportsDistanceCalculateService
    {
        Task<AirportsDetailsResultModel> GetAirportsDetailsResultAsync(AirportsListRequestModel request);
    }
}
