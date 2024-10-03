using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;

namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/AddRandomClinic")]

	public class AddRandomClinicRequest : MediatRBaseRequest<AddRandomClinicResponse>
	{
		public int Count { get; set; }
	}
}
