using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class CreateClientOperationHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
	{
		private readonly IClientRepository clientRepository;

		public CreateClientOperationHandler(IClientRepository clientRepository)
		{
			this.clientRepository = clientRepository;
		}

		public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
		{
			await clientRepository.AddAsync(request.Client, cancellationToken);
			await clientRepository.CompleteAsync(cancellationToken);

			return new CreateClientResponse();
		}
	}
}
