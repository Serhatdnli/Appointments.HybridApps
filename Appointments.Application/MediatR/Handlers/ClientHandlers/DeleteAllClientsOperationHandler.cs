using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class DeleteAllClientsOperationHandler : IRequestHandler<DeleteAllClientsRequest, DeleteAllClientsResponse>
	{
		private readonly IClientRepository ClientRepository;
		private readonly IUserRepository UserRepository;

		public DeleteAllClientsOperationHandler(IClientRepository ClientRepository, IUserRepository UserRepository)
		{
			this.ClientRepository = ClientRepository;
			this.UserRepository = UserRepository;
		}

		public async Task<DeleteAllClientsResponse> Handle(DeleteAllClientsRequest request, CancellationToken cancellationToken)
		{
			var requesterUser = await UserRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			if (requesterUser is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			if (requesterUser.Role != UserRoleType.Admin)
				throw new Exception(Constants.USER_NOT_PERMISSION);

			await ClientRepository.DeleteAllAsync();

			return new DeleteAllClientsResponse();
		}
	}
}


