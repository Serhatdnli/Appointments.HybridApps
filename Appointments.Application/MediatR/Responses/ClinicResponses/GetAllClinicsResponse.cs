using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.ClinicResponses
{
	public class GetAllClinicsResponse : MediatRBaseResponse
	{
		public List<Clinic> Clinics { get; set; }
		public int Count { get; set; }
	}

}