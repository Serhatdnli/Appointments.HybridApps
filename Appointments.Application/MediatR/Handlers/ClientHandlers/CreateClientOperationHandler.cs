


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class CreateClientOperationHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
	{
		private readonly IClientRepository ClientRepository;
		private readonly IMapper mapper;
		public CreateClientOperationHandler(IClientRepository ClientRepository, IMapper mapper)
		{
			this.ClientRepository = ClientRepository;
			this.mapper = mapper;
		}

		public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
		{
			var Client = mapper.Map<Client>(request);
			Client.CreateDate = DateTime.Now;

			await ClientRepository.AddAsync(Client, cancellationToken);
			await ClientRepository.CompleteAsync(cancellationToken);

			return new CreateClientResponse();
		}
	}
}
