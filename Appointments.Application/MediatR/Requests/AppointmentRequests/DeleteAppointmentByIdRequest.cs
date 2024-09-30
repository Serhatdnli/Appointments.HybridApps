using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
    [NetworkAddress("Appointment/DeleteAppointment")]
    public class DeleteAppointmentByIdRequest : MediatRBaseRequest<DeleteAppointmentByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
