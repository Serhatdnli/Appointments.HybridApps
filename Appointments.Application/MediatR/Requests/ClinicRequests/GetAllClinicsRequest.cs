using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;

namespace Appointments.Application.MediatR.Requests.ClinicRequests
{

	[NetworkAddress("Clinic/GetAllClinics")]

	public class GetAllClinicsRequest : MediatRBaseRequest<GetAllClinicsResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }

	}

}

