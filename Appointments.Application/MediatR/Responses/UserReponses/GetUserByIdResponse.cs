using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.UserReponses
{
	public class GetUserByIdResponse : MediatRBaseResponse
	{
        public User User{ get; set; }
    }

}