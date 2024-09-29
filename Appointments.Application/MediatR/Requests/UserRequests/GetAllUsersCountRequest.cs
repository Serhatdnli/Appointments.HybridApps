using Appointments.Application.Filters;
using Appointments.Application.MediatR.Responses.UserReponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	public class GetAllUsersCountRequest : MediatRBaseRequest<GetAllUsersCountResponse>
	{
		public UserFilter userFilter { get; set; }
	}
}
