using Appointments.Application.IRepositories;
using Appointments.Domain.Models;
using Appointments.Infrastructure.Context;

namespace Appointments.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(AppointmentContext context) : base(context)
        {
        }
    }
}
