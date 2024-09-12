using BuildingBlocks.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddAutoMapper(assembly);
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(assembly);
                configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });
            services.AddValidatorsFromAssembly(assembly);


            return services;
        }
    }
}
