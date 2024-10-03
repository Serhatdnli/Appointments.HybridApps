using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class GetClientByIdOperationHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
	{
		private readonly IClientRepository ClientRepository;

		public GetClientByIdOperationHandler(IClientRepository ClientRepository)
		{
			this.ClientRepository = ClientRepository;
		}

		public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
		{
			Client client = await ClientRepository.GetSingleAsync(x => x.Id == request.Id);

			if (client is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			return new GetClientByIdResponse { Client = client };
		}
	}
}
