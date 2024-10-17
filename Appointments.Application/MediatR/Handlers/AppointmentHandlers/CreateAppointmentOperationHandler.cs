


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class CreateAppointmentOperationHandler : IRequestHandler<CreateAppointmentRequest, CreateAppointmentResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;
		private readonly IMapper mapper;

		public CreateAppointmentOperationHandler(IAppointmentRepository AppointmentRepository, IMapper mapper)
		{
			this.AppointmentRepository = AppointmentRepository;
			this.mapper = mapper;
		}

		public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
		{
			var Appointment = mapper.Map<Appointment>(request.createDto);
			Appointment.CreateDate = DateTime.Now;

            await AppointmentRepository.AddAsync(Appointment, cancellationToken);
			await AppointmentRepository.CompleteAsync(cancellationToken);

			return new CreateAppointmentResponse();
		}
	}
}
