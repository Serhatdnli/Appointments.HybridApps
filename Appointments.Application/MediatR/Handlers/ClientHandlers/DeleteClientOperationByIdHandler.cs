using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class DeleteClientOperationByIdHandler : IRequestHandler<DeleteClientByIdRequest, DeleteClientByIdResponse>
	{
		private readonly IClientRepository clientRepository;

		public DeleteClientOperationByIdHandler(IClientRepository clientRepository)
		{
			this.clientRepository = clientRepository;
		}

		public async Task<DeleteClientByIdResponse> Handle(DeleteClientByIdRequest request, CancellationToken cancellationToken)
		{
			await clientRepository.HardDeleteAsync(request.Id, cancellationToken);
			await clientRepository.CompleteAsync(cancellationToken);

			return new DeleteClientByIdResponse();
		}
	}
}
