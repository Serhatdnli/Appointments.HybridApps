using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.ClinicResponses
{
	public class GetClinicByIdResponse : MediatRBaseResponse
	{
		public Clinic Clinic { get; set; }
	}

}