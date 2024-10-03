


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class GetAllUsersOperationHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
	{
		private readonly IUserRepository UserRepository;

		public GetAllUsersOperationHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
		{
			List<User> Users;

			var query = UserRepository.GetQueryable();
			var count = query.Count();

			if (request.Count > 0)
			{
				Users = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				Users = await query.ToListAsync(cancellationToken);
			}

			return new GetAllUsersResponse()
			{
				Count = count,
				Users = Users
			};
		}
	}
}
