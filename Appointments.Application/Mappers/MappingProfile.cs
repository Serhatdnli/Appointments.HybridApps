using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using AutoMapper;

namespace Appointments.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<Appointment, Appointment>().ReverseMap();
			CreateMap<Appointment, GetAppointmentDto>().ReverseMap();
			CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
			CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();

			CreateMap<User, User>().ReverseMap();
			CreateMap<Client, Client>().ReverseMap();
			CreateMap<Clinic, Clinic>().ReverseMap();
			CreateMap<Payment, Payment>().ReverseMap();
		}
    }
}
