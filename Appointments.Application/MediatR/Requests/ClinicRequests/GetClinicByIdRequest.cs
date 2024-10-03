using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;
namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/GetClinicById")]

	public class GetClinicByIdRequest : MediatRBaseRequest<GetClinicByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
