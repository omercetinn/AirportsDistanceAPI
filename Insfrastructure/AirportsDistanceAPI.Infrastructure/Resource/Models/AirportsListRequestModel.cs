using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportsDistanceAPI.Infrastructure.Resource.Models
{
    public class AirportsListRequestModel
    {
        public string IATA1 { get; set; }
        public string IATA2 { get; set; }
    }
}
