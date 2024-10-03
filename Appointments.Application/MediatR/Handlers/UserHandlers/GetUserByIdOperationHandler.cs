using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class GetUserByIdOperationHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
	{
		private readonly IUserRepository UserRepository;

		public GetUserByIdOperationHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
		{
			User user = await UserRepository.GetSingleAsync(x => x.Id == request.Id);

			if (user is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			return new GetUserByIdResponse { User = user };
		}
	}
}
