using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class DeletePaymentOperationHandler : IRequestHandler<DeletePaymentByIdRequest, DeletePaymentByIdResponse>
	{
		private readonly IPaymentRepository paymentRepository;

		public DeletePaymentOperationHandler(IPaymentRepository paymentRepository)
		{
			this.paymentRepository = paymentRepository;
		}

		public async Task<DeletePaymentByIdResponse> Handle(DeletePaymentByIdRequest request, CancellationToken cancellationToken)
		{
			await paymentRepository.HardDeleteAsync(request.Id, cancellationToken);
			await paymentRepository.CompleteAsync(cancellationToken);

			return new DeletePaymentByIdResponse();
		}
	}
}
