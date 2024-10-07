using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class GetAllClinicsByFilterOperationHandler : IRequestHandler<GetAllClinicsByFilterRequest, GetAllClinicsByFilterResponse>
	{
		private readonly IClinicRepository ClinicRepository;

		public GetAllClinicsByFilterOperationHandler(IClinicRepository ClinicRepository)
		{
			this.ClinicRepository = ClinicRepository;
		}

		public async Task<GetAllClinicsByFilterResponse> Handle(GetAllClinicsByFilterRequest request, CancellationToken cancellationToken)
		{
			List<Clinic> Clinics;


			var query = ClinicRepository.GetQueryable();
			var filtered = await query.Where(request.Filter.GetFilterExpression()).ToListAsync();
			var count = filtered.Count();

			if (request.Count > 0)
				Clinics = filtered.Skip(request.Index).Take(request.Count).ToList();
			else
				Clinics = filtered;


			return new GetAllClinicsByFilterResponse { Clinics = Clinics, Count = count };
		}


	}



}