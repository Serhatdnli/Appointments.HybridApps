

using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClientHandlers
{
	public class UpdateClientOperationHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
	{
		private readonly IClientRepository ClientRepository;
		private readonly IMapper mapper;

		public UpdateClientOperationHandler(IClientRepository ClientRepository, IMapper mapper)
		{
			this.ClientRepository = ClientRepository;
			this.mapper = mapper;
		}

		public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
		{
			var Client = await ClientRepository.GetSingleAsync(x => x.Id == request.Client.Id);

			if (Client is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			mapper.Map(request.Client, Client);

			await ClientRepository.UpdateAsync(Client, cancellationToken);
			await ClientRepository.CompleteAsync(cancellationToken);
			return new UpdateClientResponse();
		}
	}
}
