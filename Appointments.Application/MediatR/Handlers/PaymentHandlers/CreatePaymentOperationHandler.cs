


using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class CreatePaymentOperationHandler : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
	{
		private readonly IPaymentRepository PaymentRepository;
		private readonly IMapper mapper;

		public CreatePaymentOperationHandler(IPaymentRepository PaymentRepository, IMapper mapper)
		{
			this.PaymentRepository = PaymentRepository;
			this.mapper = mapper;
		}

		public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
		{

			var payment = mapper.Map<Payment>(request);
			payment.CreateDate = DateTime.Now;
			await PaymentRepository.AddAsync(payment, cancellationToken);
			await PaymentRepository.CompleteAsync(cancellationToken);

			return new CreatePaymentResponse();
		}
	}
}
