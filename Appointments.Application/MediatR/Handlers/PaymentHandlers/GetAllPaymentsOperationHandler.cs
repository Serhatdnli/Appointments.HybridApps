using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class GetAllPaymentsOperationHandler : IRequestHandler<GetAllPaymentsRequest, GetAllPaymentsResponse>
	{
		private readonly IPaymentRepository PaymentRepository;

		public GetAllPaymentsOperationHandler(IPaymentRepository PaymentRepository)
		{
			this.PaymentRepository = PaymentRepository;
		}

		public async Task<GetAllPaymentsResponse> Handle(GetAllPaymentsRequest request, CancellationToken cancellationToken)
		{
			List<Payment> Payments;

			var query = PaymentRepository.GetQueryable();
			var count = query.Count();

			if (request.Count > 0)
			{
				Payments = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				Payments = await query.ToListAsync(cancellationToken);
			}

			return new GetAllPaymentsResponse()
			{
				Count = count,
				Payments = Payments
			};
		}
	}
}
