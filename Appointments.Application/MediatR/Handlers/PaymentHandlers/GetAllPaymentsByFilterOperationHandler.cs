


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class GetAllPaymentsByFilterOperationHandler : IRequestHandler<GetAllPaymentsByFilterRequest, GetAllPaymentsByFilterResponse>
	{
		private readonly IPaymentRepository PaymentRepository;

		public GetAllPaymentsByFilterOperationHandler(IPaymentRepository PaymentRepository)
		{
			this.PaymentRepository = PaymentRepository;
		}

		public async Task<GetAllPaymentsByFilterResponse> Handle(GetAllPaymentsByFilterRequest request, CancellationToken cancellationToken)
		{
			List<Payment> Payments;


			var query = PaymentRepository.GetQueryable();
			var filtered = await query.Where(request.Filter.GetFilterExpression()).ToListAsync();
			var count = filtered.Count();

			if (request.Count > 0)
				Payments = filtered.Skip(request.Index).Take(request.Count).ToList();
			else
				Payments = filtered;


			return new GetAllPaymentsByFilterResponse { Payments = Payments, Count = count };
		}


	}



}