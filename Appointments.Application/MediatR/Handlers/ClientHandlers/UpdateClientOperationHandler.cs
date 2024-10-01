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
		private readonly IClientRepository clientRepository;
		private readonly IMapper mapper;

		public UpdateClientOperationHandler(IClientRepository clientRepository, IMapper mapper)
		{
			this.clientRepository = clientRepository;
			this.mapper = mapper;
		}

		public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
		{
			var client = await clientRepository.GetSingleAsync(x => x.Id == request.Client.Id);

			if (client is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			mapper.Map(request.Client, client);

			await clientRepository.UpdateAsync(client,cancellationToken);
			await clientRepository.CompleteAsync(cancellationToken);


			return new UpdateClientResponse();
		}
	}
}
