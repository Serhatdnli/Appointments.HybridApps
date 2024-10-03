using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using MediatR;
using System.Text;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
	public class AddRandomAppointmentOperationHandler : IRequestHandler<AddRandomAppointmentRequest, AddRandomAppointmentResponse>
	{
		private readonly IAppointmentRepository AppointmentRepository;

		public AddRandomAppointmentOperationHandler(IAppointmentRepository AppointmentRepository)
		{
			this.AppointmentRepository = AppointmentRepository;
		}

		public async Task<AddRandomAppointmentResponse> Handle(AddRandomAppointmentRequest request, CancellationToken cancellationToken)
		{

			List<Appointment> Appointments = new();
			for (int i = 0; i < request.Count; i++)
			{
				Appointment Appointment = new Appointment
				{


				};

				Appointments.Add(Appointment);
			}


			await AppointmentRepository.AddRangeAsync(Appointments, cancellationToken: cancellationToken);
			await AppointmentRepository.CompleteAsync(cancellationToken);


			return new AddRandomAppointmentResponse();
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
