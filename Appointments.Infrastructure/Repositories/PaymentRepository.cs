using Appointments.Application.IRepositories;
using Appointments.Domain.Models;
using Appointments.Infrastructure.Context;

namespace Appointments.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppointmentContext context) : base(context)
        {
        }
    }
}
