using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class CreateClinicOperationHandler : IRequestHandler<CreateClinicRequest, CreateClinicResponse>
	{
		private readonly IClinicRepository clinicRepository;

		public CreateClinicOperationHandler(IClinicRepository clinicRepository)
		{
			this.clinicRepository = clinicRepository;
		}

		public async Task<CreateClinicResponse> Handle(CreateClinicRequest request, CancellationToken cancellationToken)
		{
			await clinicRepository.AddAsync(request.Clinic, cancellationToken);
			await clinicRepository.CompleteAsync(cancellationToken);

			return new CreateClinicResponse();
		}
	}
}
