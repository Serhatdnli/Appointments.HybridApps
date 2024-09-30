using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAllAppointmentResponse : MediatRBaseResponse
    {
        public List<Appointment> Appointments { get; set; }
        public int Count { get; set; }
    }
}
