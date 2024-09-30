using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.PaymentResponses
{
    public class GetAllPaymentsResponse : MediatRBaseResponse
    {
        public List<Payment> Payments { get; set; }
        public int Count { get; set; }
    }
}
