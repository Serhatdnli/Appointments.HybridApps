

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
		private readonly IPaymentRepository PaymentRepository;
		private readonly IMapper mapper;

		public UpdatePaymentOperationHandler(IPaymentRepository PaymentRepository, IMapper mapper)
		{
			this.PaymentRepository = PaymentRepository;
			this.mapper = mapper;
		}

		public async Task<UpdatePaymentResponse> Handle(UpdatePaymentRequest request, CancellationToken cancellationToken)
		{
			var Payment = await PaymentRepository.GetSingleAsync(x => x.Id == request.Payment.Id);

			if (Payment is null)
			{
				throw new Exception(Constants.USER_NOT_FOUND);
			}

			mapper.Map(request.Payment, Payment);

			await PaymentRepository.UpdateAsync(Payment, cancellationToken);
			await PaymentRepository.CompleteAsync(cancellationToken);
			return new UpdatePaymentResponse();
		}
	}
}
