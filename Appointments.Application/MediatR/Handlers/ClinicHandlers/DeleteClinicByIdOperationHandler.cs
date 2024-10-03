using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class DeleteClinicByIdOperationHandler : IRequestHandler<DeleteClinicByIdRequest, DeleteClinicByIdResponse>
	{
		private readonly IClinicRepository ClinicRepository;

		public DeleteClinicByIdOperationHandler(IClinicRepository ClinicRepository)
		{
			this.ClinicRepository = ClinicRepository;
		}

		public async Task<DeleteClinicByIdResponse> Handle(DeleteClinicByIdRequest request, CancellationToken cancellationToken)
		{
			await ClinicRepository.HardDeleteAsync(request.Id, cancellationToken);
			await ClinicRepository.CompleteAsync(cancellationToken);

			return new DeleteClinicByIdResponse();
		}
	}
}

