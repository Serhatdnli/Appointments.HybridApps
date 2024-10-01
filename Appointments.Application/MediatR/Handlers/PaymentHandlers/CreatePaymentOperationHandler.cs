using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class CreatePaymentOperationHandler : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
	{
		private readonly IPaymentRepository paymentRepository;

		public CreatePaymentOperationHandler(IPaymentRepository paymentRepository)
		{
			this.paymentRepository = paymentRepository;
		}

		public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
		{
			await paymentRepository.AddAsync(request.Payment, cancellationToken);
			await paymentRepository.CompleteAsync(cancellationToken);

			return new CreatePaymentResponse();
		}
	}
}
