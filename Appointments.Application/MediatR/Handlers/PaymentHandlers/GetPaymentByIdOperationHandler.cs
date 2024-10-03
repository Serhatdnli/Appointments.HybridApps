using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class GetPaymentByIdOperationHandler : IRequestHandler<GetPaymentByIdRequest, GetPaymentByIdResponse>
	{
		private readonly IPaymentRepository PaymentRepository;

		public GetPaymentByIdOperationHandler(IPaymentRepository PaymentRepository)
		{
			this.PaymentRepository = PaymentRepository;
		}

		public async Task<GetPaymentByIdResponse> Handle(GetPaymentByIdRequest request, CancellationToken cancellationToken)
		{
			Payment payment = await PaymentRepository.GetSingleAsync(x => x.Id == request.Id);

			if (payment is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			return new GetPaymentByIdResponse { Payment = payment };
		}
	}
}
