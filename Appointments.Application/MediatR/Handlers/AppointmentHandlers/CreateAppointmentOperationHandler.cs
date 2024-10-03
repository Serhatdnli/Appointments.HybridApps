


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class CreateAppointmentOperationHandler : IRequestHandler<CreateAppointmentRequest, CreateAppointmentResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;

		public CreateAppointmentOperationHandler(IAppointmentRepository AppointmentRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
		}

		public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
		{
			await AppointmentRepository.AddAsync(request.Appointment, cancellationToken);
			await AppointmentRepository.CompleteAsync(cancellationToken);

			return new CreateAppointmentResponse();
		}
	}
}
