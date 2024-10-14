using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Enums;
namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/CreatePayment")]

	public class CreatePaymentRequest : MediatRBaseRequest<CreatePaymentResponse>
	{
		public Guid AppointmentId { get; set; }
		public float Price { get; set; }
		public PaymentType PaymentType { get; set; }
	}
}
