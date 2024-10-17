using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
    public class GetAppointmentsByDoctorAndDateOperationHandler : IRequestHandler<GetAppointmentsByDoctorAndDateRequest, GetAppointmentsByDoctorAndDateResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;
		private readonly IMapper mapper;

		public GetAppointmentsByDoctorAndDateOperationHandler(IAppointmentRepository AppointmentRepository, IMapper mapper)
		{
			this.AppointmentRepository = AppointmentRepository;
			this.mapper = mapper;
		}

		public async Task<GetAppointmentsByDoctorAndDateResponse> Handle(GetAppointmentsByDoctorAndDateRequest request, CancellationToken cancellationToken)
		{
			List<GetAppointmentDto> Appointments;

			var query = await AppointmentRepository.GetQueryable(x=> x.DoctorId == request.DoctorId && x.AppointmentTime.Date == request.Datetime.Date)
				.Include(x=> x.Client)
				.Include(x => x.Doctor)
				.Include(x => x.Clinic )
				.Include(x => x.Payments)
				.Select(x => mapper.Map<GetAppointmentDto>(x))
				.ToListAsync();

			var count = query.Count;

			if (request.Count > 0)
				Appointments = query.Skip(request.Index).Take(request.Count).ToList();
			else
				Appointments = query;


			return new GetAppointmentsByDoctorAndDateResponse { Appointments = Appointments, Count = count };
		}


	}



}