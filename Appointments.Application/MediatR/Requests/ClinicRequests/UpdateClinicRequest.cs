


using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/UpdateClinic")]

	public class UpdateClinicRequest : MediatRBaseRequest<UpdateClinicResponse>
	{
		public Clinic Clinic { get; set; }
	}
}
