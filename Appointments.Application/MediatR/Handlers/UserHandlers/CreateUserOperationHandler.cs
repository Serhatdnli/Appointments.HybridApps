using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class CreateUserOperationHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
	{
		private readonly IUserRepository UserRepository;

		public CreateUserOperationHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			await UserRepository.AddAsync(request.User, cancellationToken);
			await UserRepository.CompleteAsync(cancellationToken);

			return new CreateUserResponse();
		}
	}
}

