using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class GetAllPaymentOperationHandler : IRequestHandler<GetAllPaymentsRequest, GetAllPaymentsResponse>
	{
		private readonly IPaymentRepository paymentRepository;

		public GetAllPaymentOperationHandler(IPaymentRepository paymentRepository)
		{
			this.paymentRepository = paymentRepository;
		}

		public async Task<GetAllPaymentsResponse> Handle(GetAllPaymentsRequest request, CancellationToken cancellationToken)
		{
			List<Payment> payments;

			var query = paymentRepository.GetQueryable();
			int count = query.Count();

			if(request.Count > 0)
			{
				payments = await query.Skip(request.Index).Take(request.Count).ToListAsync(cancellationToken);
			}
			else
			{
				payments = await query.ToListAsync(cancellationToken);
			}

			return new GetAllPaymentsResponse
			{
				Count = count,
				Payments = payments
			};
		}
	}
}
