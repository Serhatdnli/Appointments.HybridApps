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
            var filtered = query.Where(x => Find(x, request.userFilter)).ToList();
            var count = filtered.Count();

            if (request.Count > 0)
                users = filtered.Skip(request.Index).Take(request.Count).ToList();
            else
                users = filtered;


            return new GetAllUsersByFilterResponse { Users = users, Count = count };
        }

        private bool Find(User user, Dictionary<UserFilterType, string> filter)
        {
            bool allConditions = true;
            foreach (var key in filter.Keys)
            {
                var value = filter[key];

                switch (key)
                {
                    case UserFilterType.Name:
                        allConditions = allConditions && user.Name.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.Surname:
                        allConditions = allConditions && user.Surname.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.Email:
                        allConditions = allConditions && user.Email.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.TcId:
                        allConditions = allConditions && user.TcId.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.PhoneNumber:
                        allConditions = allConditions && user.PhoneNumber.ToLower().Contains(value.ToLower());
                        break;
                    case UserFilterType.Role:
                        UserRoleType valueRoleType = Enum.Parse<UserRoleType>(value);
                        allConditions = allConditions && user.Role == valueRoleType;
                        break;
                    default:
                        break;
                }
            }

            return allConditions;

        }
    }



}
