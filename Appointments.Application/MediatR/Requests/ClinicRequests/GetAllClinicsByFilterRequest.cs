using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Enums.FilterTypes;
namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
	[NetworkAddress("Clinic/GetAllClinicsByFilter")]

	public class GetAllClinicsByFilterRequest : MediatRBaseRequest<GetAllClinicsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Dictionary<ClinicFilterType, string> Filter { get; set; }

	}
}