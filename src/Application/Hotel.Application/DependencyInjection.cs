using Microsoft.Extensions.DependencyInjection;

namespace HotelApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssemblies(assembly));

         
            return services;
        }
    }
}
