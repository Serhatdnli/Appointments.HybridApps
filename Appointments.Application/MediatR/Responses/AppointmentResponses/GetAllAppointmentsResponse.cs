using Appointments.Domain.Dtos;
using Appointments.Domain.Models;
namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAllAppointmentsResponse : MediatRBaseResponse
	{
		public List<AppointmentDto> Appointments { get; set; }
		public int Count { get; set; }
	}

}