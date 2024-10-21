using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{

    [NetworkAddress("Appointment/GetAppointmentsWeeklyByDoctorIdAndDate")]
    public class GetAppointmentsWeeklyByDoctorIdAndDateRequest : MediatRBaseRequest<GetAppointmentsWeeklyByDoctorIdAndDateResponse>
    {
        public Guid DoctorId { get; set; }
        public DateTime monday { get; set; }
        public DateTime saturday { get; set; }
    }
}
