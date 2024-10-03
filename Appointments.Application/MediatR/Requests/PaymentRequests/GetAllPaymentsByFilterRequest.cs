using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Enums.FilterTypes;
namespace Appointments.Application.MediatR.Requests.PaymentRequests
{
	[NetworkAddress("Payment/GetAllPaymentsByFilter")]

	public class GetAllPaymentsByFilterRequest : MediatRBaseRequest<GetAllPaymentsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Dictionary<PaymentFilterType, string> Filter { get; set; }

	}
}