using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Responses.PaymentResponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.PaymentHandlers
{
	public class DeleteAllPaymentsOperationHandler : IRequestHandler<DeleteAllPaymentsRequest, DeleteAllPaymentsResponse>
	{
		private readonly IPaymentRepository PaymentRepository;
		private readonly IUserRepository UserRepository;

		public DeleteAllPaymentsOperationHandler(IPaymentRepository PaymentRepository, IUserRepository UserRepository)
		{
			this.PaymentRepository = PaymentRepository;
			this.UserRepository = UserRepository;
		}

		public async Task<DeleteAllPaymentsResponse> Handle(DeleteAllPaymentsRequest request, CancellationToken cancellationToken)
		{
			var requesterUser = await UserRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			if (requesterUser is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			if (requesterUser.Role != UserRoleType.Admin)
				throw new Exception(Constants.USER_NOT_PERMISSION);

			await PaymentRepository.DeleteAllAsync();

			return new DeleteAllPaymentsResponse();
		}
	}
}


