using AirportsDistanceAPI.Infrastructure.Resource.Models;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serializers.Xml;
using Nest;
using Newtonsoft.Json.Linq;

namespace AirportsDistanceAPI.Infrastructure.Resource.Services
{
    public class AirportsDistanceCalculateService : IAirportsDistanceCalculateService
    {
        public async Task<AirportsDetailsResult> GetAirportsDetailsResultAsync(AirportsListRequestModel request)
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

            var response = JsonConvert.DeserializeObject<AirportsDetailsResult>(restResponse.Content);
            var response2 = JsonConvert.DeserializeObject<AirportsDetailsResult>(restResponse2.Content);
            if (response != null && response.Country != null && response.Locations != null && response2.Country != null && response2.Locations != null)
            {

                var doc = response.Locations;
                var doc2 = response2.Locations;
                if (doc.lon != null && doc.lat != null && doc2.lon != null && doc2.lat != null)
                {
                    //var result = DistanceTo(doc.lat, doc.lon, doc2.lat, doc2.lon);
                    
                    double rlat1 = Math.PI * doc.lat / 180;
                    double rlat2 = Math.PI * doc2.lat / 180;
                    double theta = doc.lon - doc2.lon;
                    double rtheta = Math.PI * theta / 180;
                    double dist =
                        Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                        Math.Cos(rlat2) * Math.Cos(rtheta);
                    dist = Math.Acos(dist);
                    dist = dist * 180 / Math.PI;
                    dist = dist * 60 * 1.1515 * 1.609344;

                    return new AirportsDetailsResult(dist);
                }

            }
            return response;
        }        

        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;


            return dist * 1.609344; // convert to mil 
        }

    }

    public interface IAirportsDistanceCalculateService
    {
        Task<AirportsDetailsResult> GetAirportsDetailsResultAsync(AirportsListRequestModel request);
    }
}
