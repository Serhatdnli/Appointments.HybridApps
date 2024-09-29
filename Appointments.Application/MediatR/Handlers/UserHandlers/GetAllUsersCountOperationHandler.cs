using Appointments.Application.FilterExtensions;
using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
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
			var query = userRepository.GetQueryable().GetAllUsersByFilter(request.userFilter);
            int count = query.Count();
            return new GetAllUsersCountResponse { UserCount = count };
        }
    }
}
