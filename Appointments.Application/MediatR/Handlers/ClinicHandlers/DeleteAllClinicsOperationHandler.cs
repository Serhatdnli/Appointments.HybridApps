using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Enums;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class DeleteAllClinicsOperationHandler : IRequestHandler<DeleteAllClinicsRequest, DeleteAllClinicsResponse>
	{
		private readonly IClinicRepository ClinicRepository;
		private readonly IUserRepository UserRepository;

		public DeleteAllClinicsOperationHandler(IClinicRepository ClinicRepository, IUserRepository UserRepository)
		{
			this.ClinicRepository = ClinicRepository;
			this.UserRepository = UserRepository;
		}

		public async Task<DeleteAllClinicsResponse> Handle(DeleteAllClinicsRequest request, CancellationToken cancellationToken)
		{
			var requesterUser = await UserRepository.GetSingleAsync(x => x.Id == request.RequesterId);

			if (requesterUser is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			if (requesterUser.Role != UserRoleType.Admin)
				throw new Exception(Constants.USER_NOT_PERMISSION);

			await ClinicRepository.DeleteAllAsync();

			return new DeleteAllClinicsResponse();
		}
	}
}


