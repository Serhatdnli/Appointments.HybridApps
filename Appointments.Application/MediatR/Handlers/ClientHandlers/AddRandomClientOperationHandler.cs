using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using MediatR;
using System.Text;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class AddRandomClientOperationHandler : IRequestHandler<AddRandomClientRequest, AddRandomClientResponse>
	{
		private readonly IClientRepository ClientRepository;

		public AddRandomClientOperationHandler(IClientRepository ClientRepository)
		{
			this.ClientRepository = ClientRepository;
		}

		public async Task<AddRandomClientResponse> Handle(AddRandomClientRequest request, CancellationToken cancellationToken)
		{

			List<Client> Clients = new();
			for (int i = 0; i < request.Count; i++)
			{
				Client Client = new Client
				{


				};

				Clients.Add(Client);
			}


			await ClientRepository.AddRangeAsync(Clients, cancellationToken: cancellationToken);
			await ClientRepository.CompleteAsync(cancellationToken);


			return new AddRandomClientResponse();
		}

		string GetRandomString(int length)
		{
			const string englishChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			StringBuilder result = new StringBuilder();
			Random random = new Random();

			for (int i = 0; i < length; i++)
			{
				int index = random.Next(englishChars.Length);
				result.Append(englishChars[index]);
			}

			return result.ToString();
		}
	}
}
