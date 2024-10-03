using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/CreatePayment")]

	public class CreatePaymentRequest : MediatRBaseRequest<CreatePaymentResponse>
	{
		public Payment Payment { get; set; }
	}
}
