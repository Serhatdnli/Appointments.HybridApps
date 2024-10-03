using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using Appointments.Shared;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class GetAppointmentByIdOperationHandler : IRequestHandler<GetAppointmentByIdRequest, GetAppointmentByIdResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;

		public GetAppointmentByIdOperationHandler(IAppointmentRepository AppointmentRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
		}

		public async Task<GetAppointmentByIdResponse> Handle(GetAppointmentByIdRequest request, CancellationToken cancellationToken)
		{
			Appointment appointment = await AppointmentRepository.GetSingleAsync(x => x.Id == request.Id);

			if (appointment is null)
				throw new Exception(Constants.USER_NOT_FOUND);

			return new GetAppointmentByIdResponse { Appointment = appointment };
		}
	}
}
