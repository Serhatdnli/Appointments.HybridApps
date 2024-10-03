


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class CreateClientOperationHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
	{
		private readonly IClientRepository ClientRepository;

		public CreateClientOperationHandler(IClientRepository ClientRepository)
		{
			this.ClientRepository = ClientRepository;
		}

		public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
		{
			await ClientRepository.AddAsync(request.Client, cancellationToken);
			await ClientRepository.CompleteAsync(cancellationToken);

			return new CreateClientResponse();
		}
	}
}
