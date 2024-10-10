


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
			Expression<Func<Appointment, bool>> myExp;
			

			var query = await AppointmentRepository.GetQueryable(x => x.AppointmentTime == request.Datetime && x.DoctorId == request.DoctorId )
				.Include(x=> x.Client)
				.Include(x => x.Doctor)
				.Include(x => x.Payments)
				.ToListAsync();
			var count = query.Count;

			if (request.Count > 0)
				Appointments = query.Skip(request.Index).Take(request.Count).ToList();
			else
				Appointments = query;


			return new GetAllAppointmentsByExpressionResponse { Appointments = Appointments, Count = count };
		}


	}



}