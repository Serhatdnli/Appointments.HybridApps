using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class DeleteClinicByIdOperationHandler : IRequestHandler<DeleteClinicByIdRequest, DeleteClinicByIdResponse>
	{
		private readonly IClinicRepository clinicRepository;

		public DeleteClinicByIdOperationHandler(IClinicRepository clinicRepository)
		{
			this.clinicRepository = clinicRepository;
		}

		public async Task<DeleteClinicByIdResponse> Handle(DeleteClinicByIdRequest request, CancellationToken cancellationToken)
		{
			await clinicRepository.HardDeleteAsync(request.Id, cancellationToken);
			await clinicRepository.CompleteAsync(cancellationToken);

			return new DeleteClinicByIdResponse();
		}
	}
}
