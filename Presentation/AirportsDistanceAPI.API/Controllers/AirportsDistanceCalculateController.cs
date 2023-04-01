﻿using AirportsDistanceAPI.Infrastructure.Resource.Models;
using AirportsDistanceAPI.Infrastructure.Resource.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace AirportsDistanceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsDistanceCalculateController : ControllerBase
    {
        private readonly IAirportsDistanceCalculateService _airportsDistanceCalculateService;

        public AirportsDistanceCalculateController(IAirportsDistanceCalculateService airportsDistanceCalculateService)
        {
            _airportsDistanceCalculateService = airportsDistanceCalculateService;
        }

        [HttpPost]
        public async Task<IActionResult> Get(AirportsListRequestModel request)
        {
            var calculate = await _airportsDistanceCalculateService.GetAirportsDetailsResultAsync(request);
            return Ok(calculate);
        }
    }
}