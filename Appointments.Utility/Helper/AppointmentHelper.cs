using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using Appointments.Utility;

namespace Appointments.Utiliy.Helper
{
    public static class AppointmentHelper
	{
		public static async Task<List<DateTime>> GetEmptyHours(Guid DocId, DateTime appointmentDate, int clinicDuration,  Guid? appointmentId = null) // eğer appointmentId girilirse, o appointmentin oldugu saatide boş geçer
		{
			List<GetAppointmentDto> appointments = new();
			List<DateTime> emptyHours = new();
			var request = new GetAppointmentsByDoctorAndDateRequest
			{
				Count = 0,
				Index = 0,
				DoctorId = DocId,
				Datetime = appointmentDate,
			};

			var response = await NetworkManager.SendAsync<GetAppointmentsByDoctorAndDateRequest, GetAppointmentsByDoctorAndDateResponse>(request);
			if (response != null)
			{
				appointments = response.Appointments;

				if(appointmentId != null)
				{
					var appointmentToRemove = appointments.FirstOrDefault(a => a.Id == appointmentId);
					if (appointmentToRemove != null)
					{
						appointments.Remove(appointmentToRemove);
					}
				}
				//Console.WriteLine("----- Randevular  -------");
				//response.Appointments.ToJson();
			}

			DateTime currentTime = new DateTime(year: appointmentDate.Year, month: appointmentDate.Month, day: appointmentDate.Day, hour: 9, minute: 0, second: 0);

			//Console.WriteLine("Appointments Count : " + Appointments.Count);

			for (int i = 0; i < 18; i++)
			{
				List<GetAppointmentDto> tempAppointments;
				bool appointmentStartTimeInOtherAppointments = true ;
				bool appointmentFinsihTimeInOtherAppointments = true ;

				tempAppointments = appointments.Where(x => x.AppointmentTime <= currentTime && x.AppointmentFinishTime >= currentTime).ToList();

				if (tempAppointments is null || tempAppointments.Count == 0)
					appointmentStartTimeInOtherAppointments = false;

				tempAppointments = appointments.Where(x => x.AppointmentTime <= currentTime.AddMinutes(clinicDuration) && x.AppointmentFinishTime >= currentTime.AddMinutes(clinicDuration)).ToList();
				if (tempAppointments is null || tempAppointments.Count == 0)
					appointmentFinsihTimeInOtherAppointments = false;

				if(!appointmentStartTimeInOtherAppointments && !appointmentFinsihTimeInOtherAppointments)
				{
					emptyHours.Add(currentTime);
				}

					currentTime = currentTime.AddMinutes(30);
			}

			return emptyHours;
		}
	}
}
