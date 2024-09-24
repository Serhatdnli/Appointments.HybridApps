﻿using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class CreateUserRequest : MediatRBaseRequest<CreateUserResponse>
    {
        public User User { get; set; }
    }
}
