using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class DeletePaymentByIdOperationHandler : IRequestHandler<DeletePaymentByIdRequest, DeletePaymentByIdResponse>
	{
		private readonly IPaymentRepository PaymentRepository;

		public DeletePaymentByIdOperationHandler(IPaymentRepository PaymentRepository)
		{
			this.PaymentRepository = PaymentRepository;
		}

		public async Task<DeletePaymentByIdResponse> Handle(DeletePaymentByIdRequest request, CancellationToken cancellationToken)
		{
			await PaymentRepository.HardDeleteAsync(request.Id, cancellationToken);
			await PaymentRepository.CompleteAsync(cancellationToken);

			return new DeletePaymentByIdResponse();
		}
	}
}

