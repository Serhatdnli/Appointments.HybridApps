using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using System.Linq.Expressions;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/GetAllAppointmentsByExpression")]

	public class GetAllAppointmentsByExpressionRequest : MediatRBaseRequest<GetAllAppointmentsByExpressionResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Guid DoctorId { get; set; }
		public DateTime Datetime { get; set; }

		//public Expression<Func<Appointment, bool>> Expression { get; set; }

	}
}