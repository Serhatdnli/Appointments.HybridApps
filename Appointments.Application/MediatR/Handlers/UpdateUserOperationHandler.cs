using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers
{
	public class UpdateUserOperationHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
	{
		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;

		public UpdateUserOperationHandler(IUserRepository userRepository, IMapper mapper)
		{
			this.userRepository = userRepository;
			this.mapper = mapper;
		}

		public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
		{
			var user = await userRepository.GetSingleAsync(x => x.Id == request.User.Id);

			if (user is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			mapper.Map(request.User, user);

			await userRepository.UpdateAsync(user);
			await userRepository.CompleteAsync();

			return new UpdateUserResponse();
		}
	}
}
