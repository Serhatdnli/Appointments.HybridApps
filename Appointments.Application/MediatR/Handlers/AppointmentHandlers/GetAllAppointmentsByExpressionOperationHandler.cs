


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class GetAllAppointmentsByExpressionOperationHandler : IRequestHandler<GetAllAppointmentsByExpressionRequest, GetAllAppointmentsByExpressionResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;

		public GetAllAppointmentsByExpressionOperationHandler(IAppointmentRepository AppointmentRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
		}

		public async Task<GetAllAppointmentsByExpressionResponse> Handle(GetAllAppointmentsByExpressionRequest request, CancellationToken cancellationToken)
		{
			List<Appointment> Appointments;


			var query = AppointmentRepository.GetQueryable();
			var expressionResult = await query.Where(request.Expression)
				.Include(x=> x.Client)
				.Include(x => x.Doctor)
				.Include(x => x.Payments)
				.Include(x => x.Payments)
				.ToListAsync();
			var count = expressionResult.Count();

			if (request.Count > 0)
				Appointments = expressionResult.Skip(request.Index).Take(request.Count).ToList();
			else
				Appointments = expressionResult;


			return new GetAllAppointmentsByExpressionResponse { Appointments = Appointments, Count = count };
		}


	}



}