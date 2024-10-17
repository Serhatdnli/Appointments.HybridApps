using Appointments.Domain.Dtos.AppointmentDtos;

namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAppointmentsByDoctorAndDateResponse : MediatRBaseResponse
	{
		public List<GetAppointmentDto> Appointments { get; set; }
		public int Count { get; set; }
	}

}