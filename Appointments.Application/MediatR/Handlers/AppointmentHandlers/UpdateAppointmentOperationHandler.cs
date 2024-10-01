using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class UpdateAppointmentOperationHandler : IRequestHandler<UpdateAppointmentRequest, UpdateAppointmentResponse>
	{
		private readonly IAppointmentRepository appointmentRepository;
		private readonly IMapper mapper;

		public UpdateAppointmentOperationHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
		{
			this.appointmentRepository = appointmentRepository;
			this.mapper = mapper;
		}

		public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentRequest request, CancellationToken cancellationToken)
		{
			var appointment = await appointmentRepository.GetSingleAsync(x => x.Id == request.Appointment.Id);

			if (appointment is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			mapper.Map(request.Appointment, appointment);

			await appointmentRepository.UpdateAsync(appointment,cancellationToken);
			await appointmentRepository.CompleteAsync(cancellationToken);
			return new UpdateAppointmentResponse();
		}
	}
}
