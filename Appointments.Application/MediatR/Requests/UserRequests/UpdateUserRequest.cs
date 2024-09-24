using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	public class UpdateUserRequest : MediatRBaseRequest<UpdateUserResponse>
	{
		public User User { get; set; }
	}
}
