using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAppointmentByIdResponse : MediatRBaseResponse
	{
		public GetAppointmentDto Appointment { get; set; }
	}

}