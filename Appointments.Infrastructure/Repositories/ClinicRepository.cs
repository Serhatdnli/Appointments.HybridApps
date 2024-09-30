using Appointments.Application.IRepositories;
using Appointments.Domain.Models;
using Appointments.Infrastructure.Context;

namespace Appointments.Infrastructure.Repositories
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(AppointmentContext context) : base(context)
        {
        }
    }
}
