using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.ClientResponses
{
	public class GetClientByIdResponse : MediatRBaseResponse
	{
		public Client Client { get; set; }
	}

}