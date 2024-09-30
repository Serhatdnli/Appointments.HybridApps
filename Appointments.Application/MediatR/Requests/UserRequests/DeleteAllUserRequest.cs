using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/DeleteAllUsers")]

    public class DeleteAllUserRequest : MediatRBaseRequest<DeleteAllUserResponse>
	{

	}
}
