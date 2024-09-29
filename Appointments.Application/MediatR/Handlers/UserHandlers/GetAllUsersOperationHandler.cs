﻿using Appointments.Application.IRepositories;
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
            var filtered = query.Where(x => Find(x, request.userFilter)).ToList();
            var count = filtered.Count();

            if (request.Count > 0)
                users = filtered.Skip(request.Index).Take(request.Count).ToList();
            else
                users = filtered;


            return new GetAllUsersResponse { Users = users, Count = count };
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
                        allConditions = allConditions && user.Surname == value;
                        break;
                    case UserFilterType.Email:
                        allConditions = allConditions && user.Email == value;
                        break;
                    case UserFilterType.TcId:
                        allConditions = allConditions && user.TcId == value;
                        break;
                    case UserFilterType.PhoneNumber:
                        allConditions = allConditions && user.PhoneNumber == value;
                        break;
                    case UserFilterType.Role:
                        allConditions = allConditions && user.Role == Enum.Parse<UserRoleType>(value);
                        break;
                    default:
                        break;
                }
            }

            return allConditions;

        }
    }



}