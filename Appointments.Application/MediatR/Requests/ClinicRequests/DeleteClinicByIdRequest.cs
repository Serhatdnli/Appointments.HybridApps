using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClinicResponses;

namespace Appointments.Application.MediatR.Requests.ClinicRequests
{
    [NetworkAddress("Clinic/DeleteClinic")]
    public class DeleteClinicByIdRequest : MediatRBaseRequest<DeleteClinicByIdResponse>
    {
        public Guid Id{ get; set; }
    }
}
