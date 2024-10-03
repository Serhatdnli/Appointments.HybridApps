

using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class UpdateUserOperationHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
	{
		private readonly IUserRepository UserRepository;
		private readonly IMapper mapper;

		public UpdateUserOperationHandler(IUserRepository UserRepository, IMapper mapper)
		{
			this.UserRepository = UserRepository;
			this.mapper = mapper;
		}

		public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
		{
			var User = await UserRepository.GetSingleAsync(x => x.Id == request.User.Id);

			if (User is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			mapper.Map(request.User, User);

			await UserRepository.UpdateAsync(User, cancellationToken);
			await UserRepository.CompleteAsync(cancellationToken);
			return new UpdateUserResponse();
		}
	}
}
