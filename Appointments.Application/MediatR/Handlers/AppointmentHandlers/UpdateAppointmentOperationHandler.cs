

using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using Appointments.Shared;
using AutoMapper;
using MediatR;

namespace Appointments.Application.MediatR.Handlers.AppointmentHandlers
{
    public class UpdateAppointmentOperationHandler : IRequestHandler<UpdateAppointmentRequest, UpdateAppointmentResponse>
    {
        private readonly IAppointmentRepository AppointmentRepository;
        private readonly IMapper mapper;

        public UpdateAppointmentOperationHandler(IAppointmentRepository AppointmentRepository, IMapper mapper)
        {
            this.AppointmentRepository = AppointmentRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentRequest request, CancellationToken cancellationToken)
        {
            var Appointment = await AppointmentRepository.GetSingleAsync(x => x.Id == request.Appointment.Id);

            if (Appointment is null)
            {
                throw new Exception(Constants.USER_NOT_FOUND);
            }

            var handledAppointment = request.Appointment;

            handledAppointment.ClientId = handledAppointment.Client.Id;
            handledAppointment.ClinicId = handledAppointment.Clinic.Id;
            handledAppointment.DoctorId = handledAppointment.Doctor.Id;


            await AppointmentRepository.UpdateAsync(handledAppointment, cancellationToken);
            await AppointmentRepository.CompleteAsync(cancellationToken);
            return new UpdateAppointmentResponse();
        }
    }
}
