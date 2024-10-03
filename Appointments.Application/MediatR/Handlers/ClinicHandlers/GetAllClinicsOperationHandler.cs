


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class GetAllClinicsOperationHandler : IRequestHandler<GetAllClinicsRequest, GetAllClinicsResponse>
	{
		private readonly IClinicRepository ClinicRepository;

		public GetAllClinicsOperationHandler(IClinicRepository ClinicRepository)
		{
			this.ClinicRepository = ClinicRepository;
		}

		public async Task<GetAllClinicsResponse> Handle(GetAllClinicsRequest request, CancellationToken cancellationToken)
		{
			List<Clinic> Clinics;

			var query = ClinicRepository.GetQueryable();
			var count = query.Count();

			if (request.Count > 0)
			{
				Clinics = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				Clinics = await query.ToListAsync(cancellationToken);
			}

			return new GetAllClinicsResponse()
			{
				Count = count,
				Clinics = Clinics
			};
		}
	}
}
