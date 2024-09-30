using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
    [NetworkAddress("Appointment/GetAllAppointment")]
    public class GetAllAppointmentRequest : MediatRBaseRequest<GetAllAppointmentResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
