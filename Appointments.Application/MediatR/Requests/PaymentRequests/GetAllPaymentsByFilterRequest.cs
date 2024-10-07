using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/GetAllPaymentsByFilter")]

	public class GetAllPaymentsByFilterRequest : MediatRBaseRequest<GetAllPaymentsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Payment Filter { get; set; }

	}
}