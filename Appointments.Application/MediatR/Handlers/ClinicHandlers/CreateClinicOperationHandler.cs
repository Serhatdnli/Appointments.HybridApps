


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class CreateClinicOperationHandler : IRequestHandler<CreateClinicRequest, CreateClinicResponse>
	{
		private readonly IClinicRepository ClinicRepository;

		public CreateClinicOperationHandler(IClinicRepository ClinicRepository)
		{
			this.ClinicRepository = ClinicRepository;
		}

		public async Task<CreateClinicResponse> Handle(CreateClinicRequest request, CancellationToken cancellationToken)
		{
			await ClinicRepository.AddAsync(request.Clinic, cancellationToken);
			await ClinicRepository.CompleteAsync(cancellationToken);

			return new CreateClinicResponse();
		}
	}
}
