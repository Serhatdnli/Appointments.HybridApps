using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class DeleteAppointmentByIdOperationHandler : IRequestHandler<DeleteAppointmentByIdRequest, DeleteAppointmentByIdResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;

		public DeleteAppointmentByIdOperationHandler(IAppointmentRepository AppointmentRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
		}

		public async Task<DeleteAppointmentByIdResponse> Handle(DeleteAppointmentByIdRequest request, CancellationToken cancellationToken)
		{
			await AppointmentRepository.HardDeleteAsync(request.Id, cancellationToken);
			await AppointmentRepository.CompleteAsync(cancellationToken);

			return new DeleteAppointmentByIdResponse();
		}
	}
}

