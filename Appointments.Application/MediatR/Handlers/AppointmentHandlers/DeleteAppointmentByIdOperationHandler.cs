using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class DeleteAppointmentByIdOperationHandler : IRequestHandler<DeleteAppointmentByIdRequest, DeleteAppointmentByIdResponse>
	{
		private readonly IAppointmentRepository appointmentRepository;

		public DeleteAppointmentByIdOperationHandler(IAppointmentRepository appointmentRepository)
		{
			this.appointmentRepository = appointmentRepository;
		}

		public async Task<DeleteAppointmentByIdResponse> Handle(DeleteAppointmentByIdRequest request, CancellationToken cancellationToken)
		{
			await appointmentRepository.HardDeleteAsync(request.Id, cancellationToken);
			await appointmentRepository.CompleteAsync(cancellationToken);

			return new DeleteAppointmentByIdResponse();
		}
	}
}
