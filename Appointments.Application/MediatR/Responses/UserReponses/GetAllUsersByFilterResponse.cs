using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.UserReponses
{
	public class GetAllUsersByFilterResponse : MediatRBaseResponse
	{
		public List<User> Users { get; set; }
		public int Count { get; set; }
	}

}