using Microsoft.Extensions.DependencyInjection;

namespace Appointments.Application.MediatR.Registiration
{
    public static class Registiration
    {
        public static IServiceCollection MediatRRegistiration(this IServiceCollection services)
        {
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Registiration).Assembly));
            return services;
        }
    }
}
