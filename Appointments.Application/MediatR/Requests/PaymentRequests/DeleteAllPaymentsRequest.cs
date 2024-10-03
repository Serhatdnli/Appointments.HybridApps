using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;

namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/DeleteAllPayments")]

	public class DeleteAllPaymentsRequest : MediatRBaseRequest<DeleteAllPaymentsResponse>
	{

	}
}
