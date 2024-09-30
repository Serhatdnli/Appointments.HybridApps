using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
    public class GetAllUsersOperationHandler : IRequestHandler<GetAllUserRequest, GetAllUsersResponse>
    {
        private readonly IUserRepository userRepository;

        public GetAllUsersOperationHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            List<User> users;


            var query = await userRepository.GetQueryable().ToListAsync(cancellationToken);
            var count = query.Count();

            if (request.Count > 0)
                users = query.Skip(request.Index).Take(request.Count).ToList();
            else
                users = query;


            return new GetAllUsersResponse { Users = users, Count = count };
        }
    }



}
