using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;

namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
    [NetworkAddress("Payment/DeletePaymentById")]
    public class DeletePaymentByIdRequest : MediatRBaseRequest<DeletePaymentResponse>
    {
        public Guid Id { get; set; }
    }
}
