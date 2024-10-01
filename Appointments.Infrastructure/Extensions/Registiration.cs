using Appointments.Application.IRepositories;
using Appointments.Infrastructure.Context;
using Appointments.Infrastructure.Repositories;
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

            services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IAppointmentRepository, AppointmentRepository>();
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<IPaymentRepository, PaymentRepository>();
			services.AddScoped<IClinicRepository, ClinicRepository>();

			return services;
        }
    }
}
