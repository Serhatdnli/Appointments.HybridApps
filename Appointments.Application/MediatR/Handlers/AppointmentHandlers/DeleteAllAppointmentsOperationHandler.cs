using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class DeleteAllAppointmentsOperationHandler : IRequestHandler<DeleteAllAppointmentsRequest, DeleteAllAppointmentsResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;
		private readonly IUserRepository UserRepository;

		public DeleteAllAppointmentsOperationHandler(IAppointmentRepository AppointmentRepository, IUserRepository UserRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
			this.UserRepository = UserRepository;
		}

		public async Task<DeleteAllAppointmentsResponse> Handle(DeleteAllAppointmentsRequest request, CancellationToken cancellationToken)
		{
			var requesterUser = await UserRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			if (requesterUser is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			if (requesterUser.Role != UserRoleType.Admin)
				throw new Exception(Constants.USER_NOT_PERMISSION);

			await AppointmentRepository.DeleteAllAsync();

			return new DeleteAllAppointmentsResponse();
		}
	}
}


