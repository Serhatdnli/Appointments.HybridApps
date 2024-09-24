using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
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
			await userRepository.DeleteAllAsync();

			return new DeleteAllUserResponse();
		}
	}
}
