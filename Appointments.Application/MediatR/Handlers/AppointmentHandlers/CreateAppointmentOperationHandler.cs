using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class CreateAppointmentOperationHandler : IRequestHandler<CreateAppointmentRequest, CreateAppointmentResponse>
	{
		private readonly IAppointmentRepository appointmentRepository;

		public CreateAppointmentOperationHandler(IAppointmentRepository appointmentRepository)
		{
			this.appointmentRepository = appointmentRepository;
		}

		public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
		{
			await appointmentRepository.AddAsync(request.Appointment, cancellationToken);
			await appointmentRepository.CompleteAsync(cancellationToken);

			return new CreateAppointmentResponse();
		}
	}
}
