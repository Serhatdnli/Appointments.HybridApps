


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class CreateClinicOperationHandler : IRequestHandler<CreateClinicRequest, CreateClinicResponse>
	{
		private readonly IClinicRepository ClinicRepository;
		private readonly IMapper mapper;

		public CreateClinicOperationHandler(IClinicRepository ClinicRepository, IMapper mapper)
		{
			this.ClinicRepository = ClinicRepository;
			this.mapper = mapper;
		}

		public async Task<CreateClinicResponse> Handle(CreateClinicRequest request, CancellationToken cancellationToken)
		{
			var clinic = mapper.Map<Clinic>(request);
			clinic.CreateDate = DateTime.Now;
			await ClinicRepository.AddAsync(clinic, cancellationToken);
			await ClinicRepository.CompleteAsync(cancellationToken);

			return new CreateClinicResponse();
		}
	}
}
