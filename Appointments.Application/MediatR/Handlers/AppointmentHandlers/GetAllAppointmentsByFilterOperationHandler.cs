


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class GetAllAppointmentsByFilterOperationHandler : IRequestHandler<GetAllAppointmentsByFilterRequest, GetAllAppointmentsByFilterResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;

		public GetAllAppointmentsByFilterOperationHandler(IAppointmentRepository AppointmentRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
		}

		public async Task<GetAllAppointmentsByFilterResponse> Handle(GetAllAppointmentsByFilterRequest request, CancellationToken cancellationToken)
		{
			List<Appointment> Appointments;


			var query = AppointmentRepository.GetQueryable();
			var filtered = await query.Where(request.Filter.GetFilterExpression())
				.Include(x => x.Client)
				.Include(x => x.Doctor).Include(x => x.Clinic)
				.Include(x => x.Payments).ToListAsync();
			var count = filtered.Count();

			if (request.Count > 0)
				Appointments = filtered.Skip(request.Index).Take(request.Count).ToList();
			else
				Appointments = filtered;


			return new GetAllAppointmentsByFilterResponse { Appointments = Appointments, Count = count };
		}


	}



}