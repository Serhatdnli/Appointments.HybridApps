using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;

namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/AddRandomPayment")]

	public class AddRandomPaymentRequest : MediatRBaseRequest<AddRandomPaymentResponse>
	{
		public int Count { get; set; }
	}
}
