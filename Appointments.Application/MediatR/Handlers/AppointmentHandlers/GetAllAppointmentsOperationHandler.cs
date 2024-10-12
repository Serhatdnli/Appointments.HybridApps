


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class GetAllAppointmentsOperationHandler : IRequestHandler<GetAllAppointmentsRequest, GetAllAppointmentsResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;
		private readonly IMapper mapper;

		public GetAllAppointmentsOperationHandler(IAppointmentRepository AppointmentRepository, IMapper mapper)
		{
			this.AppointmentRepository = AppointmentRepository;
			this.mapper = mapper;
		}

		public async Task<GetAllAppointmentsResponse> Handle(GetAllAppointmentsRequest request, CancellationToken cancellationToken)
		{
			List<GetAppointmentDto> Appointments;

			var query = AppointmentRepository.GetQueryable()
				.Include(x => x.Client)
				.Include(x => x.Doctor).
				 Include(x => x.Clinic)
				.Include(x => x.Payments)
				.Select(x => mapper.Map<GetAppointmentDto>(x));

			var count = query.Count();

			if (request.Count > 0)
			{
				Appointments = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				Appointments = await query.ToListAsync(cancellationToken);
			}

			return new GetAllAppointmentsResponse()
			{
				Count = count,
				Appointments = Appointments
			};
		}
	}
}
