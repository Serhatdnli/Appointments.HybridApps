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
	public class GetAllUsersCountOperationHandler : IRequestHandler<GetAllUsersCountRequest, GetAllUsersCountResponse>
	{
		private readonly IUserRepository userRepository;

		public GetAllUsersCountOperationHandler(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<GetAllUsersCountResponse> Handle(GetAllUsersCountRequest request, CancellationToken cancellationToken)
		{
			int count = userRepository.Count();

			return new GetAllUsersCountResponse { UserCount = count };
		}
	}
}
