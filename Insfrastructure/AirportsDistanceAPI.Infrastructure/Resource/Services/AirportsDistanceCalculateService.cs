using RestSharp;
using Newtonsoft.Json;
using AirportsDistanceAPI.Application.Aspects.Validation;
using AirportsDistanceAPI.Domain.Resource.Models;
using AirportsDistanceAPI.Application.Business.ValidationRules.FluentValidation;
using AirportsDistanceAPI.Application.Abstraction;

namespace AirportsDistanceAPI.Infrastructure.Resource.Services
{
    public class AirportsDistanceCalculateService : IAirportsDistanceCalculateService
    {
        [ValidationAspect(typeof(AirportsDistanceValidator))]
        public async Task<AirportsDetailsResultModel?> GetAirportsDetailsResultAsync(AirportsListRequestModel request)
        {   
            var url = "https://places-dev.cteleport.com/airports/{0}";

            var squadUrl1 = string.Format(url, request.IATA1);
            var squadUrl2 = string.Format(url, request.IATA2);

            var restClient = new RestClient();

            var restRequest = new RestRequest(squadUrl1, Method.Get);
            var restRequest2 = new RestRequest(squadUrl2, Method.Get);

            restRequest.RequestFormat = DataFormat.Json;
            restRequest2.RequestFormat = DataFormat.Json;

            var restResponse = restClient.Execute(restRequest);
            var restResponse2 = restClient.Execute(restRequest2);

            var response = JsonConvert.DeserializeObject<AirportsDetailsResultModel>(restResponse.Content);
            var response2 = JsonConvert.DeserializeObject<AirportsDetailsResultModel>(restResponse2.Content);

            if (response != null && response.Locations != null  && response2?.Locations != null)
            {
                var doc = response.Locations;
                var doc2 = response2.Locations;

                if (doc?.lon != null && doc?.lat != null && doc2?.lon != null && doc2?.lat != null)
                {
                    var distance = DistanceTo(doc.lat, doc.lon, doc2.lat, doc2.lon);
                    
                    return new AirportsDetailsResultModel(distance);
                }
            }

            return null;
        }        

        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;

            double distance =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);

            distance = Math.Acos(distance);
            distance = distance * 180 / Math.PI;
            distance = distance * 60 * 1.1515;

            return distance; 
        }
    }
}
