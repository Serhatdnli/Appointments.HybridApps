using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;
namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/DeleteClinicById")]
	public class DeleteClinicByIdRequest : MediatRBaseRequest<DeleteClinicByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
