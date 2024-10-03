


using Appointments.Application.FilterExtensions;
using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
	public class GetAllUsersByFilterOperationHandler : IRequestHandler<GetAllUsersByFilterRequest, GetAllUsersByFilterResponse>
	{
		private readonly IUserRepository UserRepository;

		public GetAllUsersByFilterOperationHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<GetAllUsersByFilterResponse> Handle(GetAllUsersByFilterRequest request, CancellationToken cancellationToken)
		{
			List<User> Users;


			var query = await UserRepository.GetQueryable().ToListAsync(cancellationToken);
			var filtered = query.Where(x => x.Find(request.Filter)).ToList();
			var count = filtered.Count();

			if (request.Count > 0)
				Users = filtered.Skip(request.Index).Take(request.Count).ToList();
			else
				Users = filtered;


			return new GetAllUsersByFilterResponse { Users = Users, Count = count };
		}


	}



}