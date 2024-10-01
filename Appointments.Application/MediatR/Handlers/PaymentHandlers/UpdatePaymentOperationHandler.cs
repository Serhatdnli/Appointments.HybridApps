using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class UpdatePaymentOperationHandler : IRequestHandler<UpdatePaymentRequest, UpdatePaymentResponse>
	{
		private readonly IPaymentRepository paymentRepository;
		private readonly IMapper mapper;

		public UpdatePaymentOperationHandler(IMapper mapper, IPaymentRepository paymentRepository)
		{
			this.mapper = mapper;
			this.paymentRepository = paymentRepository;
		}

		public async Task<UpdatePaymentResponse> Handle(UpdatePaymentRequest request, CancellationToken cancellationToken)
		{
			var payment = await paymentRepository.GetSingleAsync(x => x.Id == request.Payment.Id);

			if (payment is null)
				throw new Exception(Constants.USER_NOT_FOUND);



			mapper.Map( request.Payment, payment);

			await paymentRepository.UpdateAsync(payment, cancellationToken);
			await paymentRepository.CompleteAsync(cancellationToken);

			return new UpdatePaymentResponse();
		}
	}
}
