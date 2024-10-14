using Appointments.Domain.Dtos;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAppointmentByIdResponse : MediatRBaseResponse
	{
		public AppointmentDto Appointment { get; set; }
	}

}