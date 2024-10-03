using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
			//List<Payment> Payments;


			//var query = await PaymentRepository.GetQueryable().ToListAsync(cancellationToken);
			//var filtered = query.Where(x => x.Find(request.Filter)).ToList();
			//var count = filtered.Count();

			//if (request.Count > 0)
			//	Payments = filtered.Skip(request.Index).Take(request.Count).ToList();
			//else
			//	Payments = filtered;


			//return new GetAllPaymentsByFilterResponse { Payments = Payments, Count = count };

			return null;
		}


	}



}