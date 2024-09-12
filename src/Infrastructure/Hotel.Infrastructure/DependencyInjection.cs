using HotelData.Abstractions;
using Hotel.Infrastructure.Models;
using Hotel.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ILocationHotelRepository, LocationHotelRepository>();
            services.AddSingleton<Hotels>();
            return services;
        }
    }
}
