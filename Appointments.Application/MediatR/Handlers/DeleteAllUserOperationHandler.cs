using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Handlers
{
	public class DeleteAllUserOperationHandler : IRequestHandler<DeleteAllUserRequest, DeleteAllUserResponse>
	{
		private readonly IUserRepository userRepository;

		public DeleteAllUserOperationHandler(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<DeleteAllUserResponse> Handle(DeleteAllUserRequest request, CancellationToken cancellationToken)
		{
			var requesterUser = await userRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			if (requesterUser is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			if (requesterUser.Role != UserRoleType.Admin)
				throw new Exception(Constants.USER_NOT_PERMISSION);

			await userRepository.DeleteAllAsync();

			return new DeleteAllUserResponse();
		}
	}
}
