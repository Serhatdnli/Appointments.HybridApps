using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class GetClinicByIdOperationHandler : IRequestHandler<GetClinicByIdRequest, GetClinicByIdResponse>
	{
		private readonly IClinicRepository ClinicRepository;

		public GetClinicByIdOperationHandler(IClinicRepository ClinicRepository)
		{
			this.ClinicRepository = ClinicRepository;
		}

		public async Task<GetClinicByIdResponse> Handle(GetClinicByIdRequest request, CancellationToken cancellationToken)
		{
			Clinic clinic = await ClinicRepository.GetSingleAsync(x => x.Id == request.Id);

			if (clinic is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			return new GetClinicByIdResponse { Clinic = clinic };
		}
	}
}
