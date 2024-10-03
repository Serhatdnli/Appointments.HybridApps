


using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/UpdatePayment")]

	public class UpdatePaymentRequest : MediatRBaseRequest<UpdatePaymentResponse>
	{
		public Payment Payment { get; set; }
	}
}
