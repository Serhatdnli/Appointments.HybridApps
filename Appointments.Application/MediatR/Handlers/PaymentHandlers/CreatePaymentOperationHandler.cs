


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class CreatePaymentOperationHandler : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
	{
		private readonly IPaymentRepository PaymentRepository;

		public CreatePaymentOperationHandler(IPaymentRepository PaymentRepository)
		{
			this.PaymentRepository = PaymentRepository;
		}

		public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
		{
			await PaymentRepository.AddAsync(request.Payment, cancellationToken);
			await PaymentRepository.CompleteAsync(cancellationToken);

			return new CreatePaymentResponse();
		}
	}
}
