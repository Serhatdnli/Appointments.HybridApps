using Appointments.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appointments.Infrastructure.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentContext>(conf =>
            {
                var connectionString = configuration["ConnectionString"];
                conf.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            return services;
        }
    }
}
