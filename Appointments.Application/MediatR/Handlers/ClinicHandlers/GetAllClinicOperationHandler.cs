using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class GetAllClinicOperationHandler : IRequestHandler<GetAllClinicsRequest, GetAllClinicResponse>
	{
		private readonly IClinicRepository clinicRepository;

		public GetAllClinicOperationHandler(IClinicRepository clinicRepository)
		{
			this.clinicRepository = clinicRepository;
		}

		public async Task<GetAllClinicResponse> Handle(GetAllClinicsRequest request, CancellationToken cancellationToken)
		{
			List<Clinic> clinics;

			var query = clinicRepository.GetQueryable();
			int count = query.Count();


			if (request.Count > 0)
			{
				clinics = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				clinics = await query.ToListAsync(cancellationToken);
			}

			return new GetAllClinicResponse
			{
				Clinics = clinics,
				Count = count
			};

		}
	}
}
