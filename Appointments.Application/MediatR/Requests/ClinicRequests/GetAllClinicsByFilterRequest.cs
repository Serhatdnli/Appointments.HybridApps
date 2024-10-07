using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/GetAllClinicsByFilter")]

	public class GetAllClinicsByFilterRequest : MediatRBaseRequest<GetAllClinicsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Clinic Filter { get; set; }

	}
}