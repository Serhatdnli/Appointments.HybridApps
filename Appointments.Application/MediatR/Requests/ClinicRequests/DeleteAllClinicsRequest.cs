using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;

namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/DeleteAllClinics")]

	public class DeleteAllClinicsRequest : MediatRBaseRequest<DeleteAllClinicsResponse>
	{

	}
}
