using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;

namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
    [NetworkAddress("Payment/GetAllPayments")]
    public class GetAllPaymentsRequest : MediatRBaseRequest<GetAllPaymentsResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
