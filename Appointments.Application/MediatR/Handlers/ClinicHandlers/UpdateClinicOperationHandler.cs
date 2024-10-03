

using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class UpdateClinicOperationHandler : IRequestHandler<UpdateClinicRequest, UpdateClinicResponse>
	{
		private readonly IClinicRepository ClinicRepository;
		private readonly IMapper mapper;

		public UpdateClinicOperationHandler(IClinicRepository ClinicRepository, IMapper mapper)
		{
			this.ClinicRepository = ClinicRepository;
			this.mapper = mapper;
		}

		public async Task<UpdateClinicResponse> Handle(UpdateClinicRequest request, CancellationToken cancellationToken)
		{
			var Clinic = await ClinicRepository.GetSingleAsync(x => x.Id == request.Clinic.Id);

			if (Clinic is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			mapper.Map(request.Clinic, Clinic);

			await ClinicRepository.UpdateAsync(Clinic, cancellationToken);
			await ClinicRepository.CompleteAsync(cancellationToken);
			return new UpdateClinicResponse();
		}
	}
}
