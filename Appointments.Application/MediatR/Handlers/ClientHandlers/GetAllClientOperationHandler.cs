using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class GetAllClientOperationHandler : IRequestHandler<GetAllClientRequest, GetAllClientResponse>
	{
		private readonly IClientRepository clientRepository;

		public GetAllClientOperationHandler(IClientRepository clientRepository)
		{
			this.clientRepository = clientRepository;
		}

		public async Task<GetAllClientResponse> Handle(GetAllClientRequest request, CancellationToken cancellationToken)
		{
			List<Client> clients;

			var query = clientRepository.GetQueryable();
			int count = query.Count();

			if(request.Count > 0)
			{
				clients = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				clients = await query.ToListAsync(cancellationToken);
			}

			return new GetAllClientResponse
			{
				Clients = clients,
				Count = count
			};

		}
	}
}
