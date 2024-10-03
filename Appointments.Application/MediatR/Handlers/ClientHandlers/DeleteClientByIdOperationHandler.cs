using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class DeleteClientByIdOperationHandler : IRequestHandler<DeleteClientByIdRequest, DeleteClientByIdResponse>
	{
		private readonly IClientRepository ClientRepository;

		public DeleteClientByIdOperationHandler(IClientRepository ClientRepository)
		{
			this.ClientRepository = ClientRepository;
		}

		public async Task<DeleteClientByIdResponse> Handle(DeleteClientByIdRequest request, CancellationToken cancellationToken)
		{
			await ClientRepository.HardDeleteAsync(request.Id, cancellationToken);
			await ClientRepository.CompleteAsync(cancellationToken);

			return new DeleteClientByIdResponse();
		}
	}
}

