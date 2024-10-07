


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class GetAllClientsByFilterOperationHandler : IRequestHandler<GetAllClientsByFilterRequest, GetAllClientsByFilterResponse>
	{
		private readonly IClientRepository ClientRepository;

		public GetAllClientsByFilterOperationHandler(IClientRepository ClientRepository)
		{
			this.ClientRepository = ClientRepository;
		}

		public async Task<GetAllClientsByFilterResponse> Handle(GetAllClientsByFilterRequest request, CancellationToken cancellationToken)
		{
			List<Client> Clients;


			var query = ClientRepository.GetQueryable();
			var filtered = await query.Where(request.Filter.GetFilterExpression()).ToListAsync();
			var count = filtered.Count();

			if (request.Count > 0)
				Clients = filtered.Skip(request.Index).Take(request.Count).ToList();
			else
				Clients = filtered;


			return new GetAllClientsByFilterResponse { Clients = Clients, Count = count };
		}


	}



}