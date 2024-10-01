using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class GetAllAppointmentOperationHandler : IRequestHandler<GetAllAppointmentRequest, GetAllAppointmentResponse>
	{
		private readonly IAppointmentRepository appointmentRepository;

		public GetAllAppointmentOperationHandler(IAppointmentRepository appointmentRepository)
		{
			this.appointmentRepository = appointmentRepository;
		}

		public async Task<GetAllAppointmentResponse> Handle(GetAllAppointmentRequest request, CancellationToken cancellationToken)
		{
			List<Appointment> appointments;

			var query = appointmentRepository.GetQueryable();
			var count = query.Count();

			if(request.Count > 0)
			{
				appointments = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				appointments = await query.ToListAsync(cancellationToken);
			}

			return new GetAllAppointmentResponse()
			{
				Count = count,
				Appointments = appointments
			};
		}
	}
}
