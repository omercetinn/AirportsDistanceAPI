using AirportsDistanceAPI.Infrastructure.Resource.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirportsDistanceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IAirportsDistanceCalculateService, AirportsDistanceCalculateService>();
        }
    }
}