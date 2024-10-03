


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class GetAllClientsOperationHandler : IRequestHandler<GetAllClientsRequest, GetAllClientsResponse>
	{
		private readonly IClientRepository ClientRepository;

		public GetAllClientsOperationHandler(IClientRepository ClientRepository)
		{
			this.ClientRepository = ClientRepository;
		}

		public async Task<GetAllClientsResponse> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
		{
			List<Client> Clients;

			var query = ClientRepository.GetQueryable();
			var count = query.Count();

			if (request.Count > 0)
			{
				Clients = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				Clients = await query.ToListAsync(cancellationToken);
			}

			return new GetAllClientsResponse()
			{
				Count = count,
				Clients = Clients
			};
		}
	}
}
