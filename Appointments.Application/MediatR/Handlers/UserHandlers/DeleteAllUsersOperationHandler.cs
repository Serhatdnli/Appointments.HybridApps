using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class DeleteAllUsersOperationHandler : IRequestHandler<DeleteAllUsersRequest, DeleteAllUsersResponse>
	{
		private readonly IUserRepository UserRepository;

		public DeleteAllUsersOperationHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
			this.UserRepository = UserRepository;
		}

		public async Task<DeleteAllUsersResponse> Handle(DeleteAllUsersRequest request, CancellationToken cancellationToken)
		{
			var requesterUser = await UserRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			if (requesterUser is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			if (requesterUser.Role != UserRoleType.Admin)
				throw new Exception(Constants.USER_NOT_PERMISSION);

			await UserRepository.DeleteAllAsync();

			return new DeleteAllUsersResponse();
		}
	}
}


