using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.PaymentResponses
{
	public class GetPaymentByIdResponse : MediatRBaseResponse
	{
		public Payment Payment { get; set; }
	}

}