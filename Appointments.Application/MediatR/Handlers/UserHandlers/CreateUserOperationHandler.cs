using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
    internal class CreateUserOperationHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {

        private readonly IUserRepository userRepository;

        public CreateUserOperationHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var requesterUser = await userRepository.GetSingleAsync(x => x.Id == request.RequesterId);

            //if (requesterUser is null)
            //    throw new Exception(Constants.USER_NOT_FOUND);

            //if (requesterUser.Role != UserRoleType.Admin)
            //    throw new Exception(Constants.USER_NOT_PERMISSION);

            await userRepository.AddAsync(request.User, cancellationToken: cancellationToken);
            await userRepository.CompleteAsync(cancellationToken);

            return new CreateUserResponse();
        }
    }
}
