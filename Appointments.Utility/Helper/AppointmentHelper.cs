using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos;
using Appointments.Shared.Extensions;
using Appointments.Utility;

namespace Appointments.Utiliy.Helper
{
    public static class AppointmentHelper
    {
        public static async Task<List<DateTime>> GetEmptyHours(Guid DocId, DateTime date, (Guid, DateTime) editedAppointmentInfos = default)
        {
            List<AppointmentDto> appointments = new();
            List<DateTime> emptyHours = new();
            var request = new GetAppointmentsByDoctorAndDateRequest
            {
                Count = 0,
                Index = 0,
                DoctorId = DocId,
                Datetime = date,
            };

            var response = await NetworkManager.SendAsync<GetAppointmentsByDoctorAndDateRequest, GetAppointmentsByDoctorAndDateResponse>(request);
            if (response != null)
            {
                appointments = response.Appointments;
                Console.WriteLine("----- Randevular  -------");
                response.Appointments.ToJson();
            }

            DateTime currentTime = new DateTime(year: date.Year, month: date.Month, day: date.Day, hour: 9, minute: 0, second: 0);

            //Console.WriteLine("Appointments Count : " + Appointments.Count);

            for (int i = 0; i < 18; i++)
            {
                var emptyAppointments = appointments.Where(x => (x.Client.Id == editedAppointmentInfos.Item1 && x.AppointmentTime == editedAppointmentInfos.Item2) || (x.AppointmentTime <= currentTime && x.AppointmentFinishTime >= currentTime)).ToList();
                if (emptyAppointments is null || emptyAppointments.Count == 0)
                    emptyHours.Add(currentTime);

                currentTime = currentTime.AddMinutes(30);
            }

            return emptyHours;
        }
    }
}
