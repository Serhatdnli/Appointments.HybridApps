using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class CreateUserOperationHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
	{
		private readonly IUserRepository UserRepository;
		private readonly IMapper mapper;

		public CreateUserOperationHandler(IUserRepository UserRepository, IMapper mapper)
		{
			this.UserRepository = UserRepository;
			this.mapper = mapper;
		}

		public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var user = mapper.Map<User>(request);
			user.CreateDate = DateTime.Now;

			await UserRepository.AddAsync(user, cancellationToken);
			await UserRepository.CompleteAsync(cancellationToken);

			return new CreateUserResponse();
		}
	}
}

