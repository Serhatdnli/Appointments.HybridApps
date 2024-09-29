using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers
{
    public class DeleteUserWithTcIdOperationHandler : IRequestHandler<DeleteUserWithTcIdRequest, DeleteUserWithTcIdResponse>
    {
        private readonly IUserRepository userRepository;

        public DeleteUserWithTcIdOperationHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<DeleteUserWithTcIdResponse> Handle(DeleteUserWithTcIdRequest request, CancellationToken cancellationToken)
        {
			//var requestedUser = await userRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			//if (requestedUser is null)
			//	throw new Exception(Constants.USER_NOT_FOUND);

			//if (requestedUser.Role != UserRoleType.Admin)
			//	throw new Exception(Constants.USER_NOT_PERMISSION);

			var user = await userRepository.GetSingleAsync(x => x.TcId == request.TcId);

			if (user is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			await userRepository.HardDeleteAsync(user, cancellationToken: cancellationToken);
			await userRepository.CompleteAsync(cancellationToken);

			return new DeleteUserWithTcIdResponse();
		}
    }
}
