using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using MediatR;
using System.Text;

namespace Appointments.Application.MediatR.Handlers.ClinicHandlers
{
	public class AddRandomClinicOperationHandler : IRequestHandler<AddRandomClinicRequest, AddRandomClinicResponse>
	{
		private readonly IClinicRepository ClinicRepository;

		public AddRandomClinicOperationHandler(IClinicRepository ClinicRepository)
		{
			this.ClinicRepository = ClinicRepository;
		}

		public async Task<AddRandomClinicResponse> Handle(AddRandomClinicRequest request, CancellationToken cancellationToken)
		{

			List<Clinic> Clinics = new();
			for (int i = 0; i < request.Count; i++)
			{
				Clinic Clinic = new Clinic
				{


				};

				Clinics.Add(Clinic);
			}


			await ClinicRepository.AddRangeAsync(Clinics, cancellationToken: cancellationToken);
			await ClinicRepository.CompleteAsync(cancellationToken);


			return new AddRandomClinicResponse();
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
