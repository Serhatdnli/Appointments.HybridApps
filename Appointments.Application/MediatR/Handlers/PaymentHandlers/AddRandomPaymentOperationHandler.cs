using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Models;
using MediatR;
using System.Text;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class AddRandomPaymentOperationHandler : IRequestHandler<AddRandomPaymentRequest, AddRandomPaymentResponse>
	{
		private readonly IPaymentRepository PaymentRepository;

		public AddRandomPaymentOperationHandler(IPaymentRepository PaymentRepository)
		{
			this.PaymentRepository = PaymentRepository;
		}

		public async Task<AddRandomPaymentResponse> Handle(AddRandomPaymentRequest request, CancellationToken cancellationToken)
		{

			List<Payment> Payments = new();
			for (int i = 0; i < request.Count; i++)
			{
				Payment Payment = new Payment
				{


				};

				Payments.Add(Payment);
			}


			await PaymentRepository.AddRangeAsync(Payments, cancellationToken: cancellationToken);
			await PaymentRepository.CompleteAsync(cancellationToken);


			return new AddRandomPaymentResponse();
		}

		string GetRandomString(int length)
		{
			const string englishChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			StringBuilder result = new StringBuilder();
			Random random = new Random();

			for (int i = 0; i < length; i++)
			{
				int index = random.Next(englishChars.Length);
				result.Append(englishChars[index]);
			}

			return result.ToString();
		}
	}
}
