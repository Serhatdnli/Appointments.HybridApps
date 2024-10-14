using Appointments.Domain.Dtos;

namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAppointmentsByDoctorAndDateResponse : MediatRBaseResponse
	{
		public List<AppointmentDto> Appointments { get; set; }
		public int Count { get; set; }
	}

}