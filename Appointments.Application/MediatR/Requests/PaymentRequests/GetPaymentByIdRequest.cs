using Appointments.Application.Attributes;

using Appointments.Application.MediatR.Responses.PaymentResponses;
namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/GetPaymentById")]

	public class GetPaymentByIdRequest : MediatRBaseRequest<GetPaymentByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
