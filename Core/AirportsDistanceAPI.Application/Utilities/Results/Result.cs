﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportsDistanceAPI.Application.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        //SADECE SUCCESS VERMEK İSTENİRSE
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
