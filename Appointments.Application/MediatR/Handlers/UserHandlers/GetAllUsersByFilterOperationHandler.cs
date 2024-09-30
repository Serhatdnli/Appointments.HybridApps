using Appointments.Application.FilterExtensions;
using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.UserHandlers
{
    public class GetAllUsersByFilterOperationHandler : IRequestHandler<GetAllUserByFilterRequest, GetAllUsersByFilterResponse>
    {
        private readonly IUserRepository userRepository;

        public GetAllUsersByFilterOperationHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<GetAllUsersByFilterResponse> Handle(GetAllUserByFilterRequest request, CancellationToken cancellationToken)
        {
            List<User> users;


            var query = await userRepository.GetQueryable().ToListAsync(cancellationToken);
            var filtered = query.Where(x => x.Find(request.userFilter)).ToList();
            var count = filtered.Count();

            if (request.Count > 0)
                users = filtered.Skip(request.Index).Take(request.Count).ToList();
            else
                users = filtered;


            return new GetAllUsersByFilterResponse { Users = users, Count = count };
        }

        
    }



}
