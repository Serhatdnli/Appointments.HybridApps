using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/CreateClinic")]

	public class CreateClinicRequest : MediatRBaseRequest<CreateClinicResponse>
	{
		public string Name { get; set; }
		public int Minute { get; set; } = 0;

	}
}
