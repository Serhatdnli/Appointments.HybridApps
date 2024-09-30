using Appointments.Application.IRepositories;
using Appointments.Domain.Models;
using Appointments.Infrastructure.Context;

namespace Appointments.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentContext context) : base(context)
        {
        }
    }
}
