using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class UpdateClinicOperationHandler : IRequestHandler<UpdateClinicRequest, UpdateClinicResponse>
	{
		private readonly IClinicRepository clinicRepository;
		private readonly IMapper mapper;

		public UpdateClinicOperationHandler(IMapper mapper, IClinicRepository clinicRepository)
		{
			this.mapper = mapper;
			this.clinicRepository = clinicRepository;
		}

		public async Task<UpdateClinicResponse> Handle(UpdateClinicRequest request, CancellationToken cancellationToken)
		{
			var clinic = await clinicRepository.GetSingleAsync(x => x.Id == request.Clinic.Id);

			if (clinic is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			mapper.Map(request.Clinic, clinic);

			await clinicRepository.UpdateAsync(clinic, cancellationToken);
			await clinicRepository.CompleteAsync(cancellationToken);

			return new UpdateClinicResponse();
		}
	}
}
