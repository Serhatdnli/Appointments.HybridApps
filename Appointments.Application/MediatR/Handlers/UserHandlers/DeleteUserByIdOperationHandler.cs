using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class DeleteUserByIdOperationHandler : IRequestHandler<DeleteUserByIdRequest, DeleteUserByIdResponse>
	{
		private readonly IUserRepository UserRepository;

		public DeleteUserByIdOperationHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<DeleteUserByIdResponse> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
		{
			await UserRepository.HardDeleteAsync(request.Id, cancellationToken);
			await UserRepository.CompleteAsync(cancellationToken);

			return new DeleteUserByIdResponse();
		}
	}
}

