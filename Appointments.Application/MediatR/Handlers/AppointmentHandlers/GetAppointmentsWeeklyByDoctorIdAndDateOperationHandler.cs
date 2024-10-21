using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
    public class GetAppointmentsWeeklyByDoctorIdAndDateOperationHandler : IRequestHandler<GetAppointmentsWeeklyByDoctorIdAndDateRequest, GetAppointmentsWeeklyByDoctorIdAndDateResponse>
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;

        public GetAppointmentsWeeklyByDoctorIdAndDateOperationHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }

        public async Task<GetAppointmentsWeeklyByDoctorIdAndDateResponse> Handle(GetAppointmentsWeeklyByDoctorIdAndDateRequest request, CancellationToken cancellationToken)
        {
            List<GetAppointmentDto> appointments;
      

            appointments = await appointmentRepository.GetQueryable()
                 .Where(x => x.DoctorId == request.DoctorId && x.AppointmentTime < request.saturday && x.AppointmentTime > request.monday)
                 .Include(x => x.Clinic)
                 .OrderBy(x => x.AppointmentTime)
                 .Select(x => mapper.Map<GetAppointmentDto>(x))
                 .ToListAsync();

            return new GetAppointmentsWeeklyByDoctorIdAndDateResponse
            {
                Appointments = appointments,
                Count = appointments.Count()
            };
        }
    }
}
