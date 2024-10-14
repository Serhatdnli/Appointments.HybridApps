using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos;
using Appointments.Domain.Models;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
    public class GetAppointmentByIdOperationHandler : IRequestHandler<GetAppointmentByIdRequest, GetAppointmentByIdResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;
		private readonly IMapper mapper;

		public GetAppointmentByIdOperationHandler(IAppointmentRepository AppointmentRepository, IMapper mapper)
		{
			this.AppointmentRepository = AppointmentRepository;
			this.mapper = mapper;
		}

		public async Task<GetAppointmentByIdResponse> Handle(GetAppointmentByIdRequest request, CancellationToken cancellationToken)
		{
			Appointment appo = await AppointmentRepository.GetSingleAsync(x => x.Id == request.Id);
			AppointmentDto appointment = mapper.Map<AppointmentDto>(appo);

			if (appointment is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			return new GetAppointmentByIdResponse { Appointment = appointment };
		}
	}
}
