using Appointments.Application.IRepositories;
using Appointments.Domain.Models;
using Appointments.Infrastructure.Context;

namespace Appointments.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payments>, IPaymentRepository
    {
        public PaymentRepository(AppointmentContext context) : base(context)
        {
        }
    }
}
