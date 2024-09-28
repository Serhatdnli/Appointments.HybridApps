using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Appointments.Application.MediatR.Responses.UserReponses
{
	public class GetAllUsersCountResponse : MediatRBaseResponse
	{
		[JsonPropertyName("userCount")]
        public int UserCount { get; set; }
    }
}
